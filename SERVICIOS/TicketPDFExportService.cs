using BE;
using BE.PN;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using PdfSharp;


namespace SERVICIOS
{
    /// <summary>
    /// Servicio para exportar tickets a PDF
    /// Este servicio recibe los datos ya cargados para evitar referencias circulares
    /// </summary>
    public class TicketPDFExportService
    {
        // Fonts
        private readonly XFont _fontTitle = new XFont("Arial", 20, XFontStyle.Bold);
        private readonly XFont _fontSubtitle = new XFont("Arial", 14, XFontStyle.Bold);
        private readonly XFont _fontHeader = new XFont("Arial", 11, XFontStyle.Bold);
        private readonly XFont _fontNormal = new XFont("Arial", 10, XFontStyle.Regular);
        private readonly XFont _fontSmall = new XFont("Arial", 9, XFontStyle.Regular);
        private readonly XFont _fontItalic = new XFont("Arial", 9, XFontStyle.Italic);

        // Colors
        private readonly XBrush _primaryColor = new XSolidBrush(XColor.FromArgb(33, 150, 243));
        private readonly XBrush _grayColor = new XSolidBrush(XColor.FromArgb(128, 128, 128));



        /// <summary>
        /// Datos necesarios para exportar un ticket
        /// </summary>
        public class TicketExportData
        {
            public Ticket Ticket { get; set; }
            public List<ValorCampoTicket> CamposPersonalizados { get; set; }

     
            public Dictionary<int, DefinicionCampoPersonalizado> DefinicionesCampos { get; set; }
            public List<TicketHistorico> Historial { get; set; }
            public Dictionary<Guid, string> UsuariosNombres { get; set; }
            public Dictionary<int, string> PrioridadesNombres { get; set; }
            public Dictionary<int, string> CategoriasNombres { get; set; }
            public Dictionary<int, string> EstadosNombres { get; set; }
            public List<Comentario> Comentarios { get; set; }
            public string NombrePrioridadActual { get; set; }
        }

        /// <summary>
        /// Exporta un ticket a PDF usando los datos proporcionados
        /// </summary>
        public bool ExportarTicket(TicketExportData datos, string rutaArchivo, bool abrirDespues = false)
        {
            if (datos?.Ticket == null)
                throw new ArgumentNullException(nameof(datos), "Los datos del ticket no pueden ser nulos");

            try
            {
                // 1) Crear documento
                var document = new PdfDocument();
                document.Info.Title = $"Ticket #{datos.Ticket.Numero}";
                document.Info.Author = "Sistema de Tickets";
                document.Info.Subject = datos.Ticket.Asunto;
                document.Info.Creator = "TicketPDFExportService";

                double margenIzq = 40, margenDer = 40;

                // 2) Lista de páginas + sus XGraphics
                var pages = new List<(PdfPage page, XGraphics gfx)>();

                // Helper: agrega una nueva página y su gfx
                Action resetPage = () =>
                {
                    var pg = document.AddPage();
                    pg.Size = PageSize.A4;
                    var gr = XGraphics.FromPdfPage(pg);
                    pages.Add((pg, gr));
                };

                // Página inicial
                resetPage();
                PdfPage currentPage = pages[0].page;
                XGraphics gfx = pages[0].gfx;
                double yPos = 40;
                double ancho = currentPage.Width - margenIzq - margenDer;

                // 3) Dibujo contenido de la 1ª página
                DibujarHeader(gfx, currentPage, datos.Ticket, ref yPos);
                DibujarSeccionInformacionBasica(gfx, currentPage, datos, ref yPos, margenIzq, ancho);
                DibujarSeccionAsuntoDescripcion(gfx, currentPage, datos.Ticket, ref yPos, margenIzq, ancho);
                if (datos.CamposPersonalizados?.Count > 0)
                    DibujarSeccionCamposPersonalizados(gfx, currentPage, datos, ref yPos, margenIzq, ancho);

                // 4) Página nueva para Historial
                if (datos.Historial?.Count > 0)
                {
                    resetPage();
                    var last = pages.Last();
                    currentPage = last.page;
                    gfx = last.gfx;
                    yPos = 40;
                    ancho = currentPage.Width - margenIzq - margenDer;
                    DibujarSeccionHistorial(gfx, currentPage, document, datos, ref yPos, margenIzq, ancho);
                }

                // 5) Página nueva para Comentarios
                if (datos.Comentarios?.Count > 0)
                {
                    resetPage();
                    var last = pages.Last();
                    currentPage = last.page;
                    gfx = last.gfx;
                    yPos = 40;
                    ancho = currentPage.Width - margenIzq - margenDer;
                    DibujarSeccionComentarios(gfx, currentPage, document, datos.Comentarios, ref yPos, margenIzq, ancho);
                }

                // 6) Dibujar footer en **el mismo** XGraphics de cada página
                for (int i = 0; i < pages.Count; i++)
                {
                    var (pg, gr) = pages[i];
                    DibujarFooter(gr, pg, i + 1, pages.Count);
                }

                // 7) Guardar y disponer todos los gráficos
                document.Save(rutaArchivo);
                foreach (var (_, gr) in pages)
                    gr.Dispose();

                if (abrirDespues)
                    Process.Start(rutaArchivo);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al exportar PDF: {ex.Message}", ex);
            }
        }


        private void DibujarHeader(XGraphics gfx, PdfPage page, Ticket ticket, ref double yPos)
        {
            // Rectángulo de fondo para el header
            gfx.DrawRectangle(_primaryColor, 0, 0, page.Width, 80);

            // Título
            gfx.DrawString($"TICKET #{ticket.Numero}", _fontTitle,
                XBrushes.White, new XRect(0, 25, page.Width, 30),
                XStringFormats.TopCenter);

            // Fecha de generación del PDF
            gfx.DrawString($"Generado el {DateTime.Now:dd/MM/yyyy HH:mm}",
                _fontSmall, XBrushes.White,
                new XRect(0, 55, page.Width - 20, 20),
                XStringFormats.TopRight);

            yPos = 100;
        }

        private void DibujarFooter(XGraphics gfx, PdfPage page, int numeroPagina, int totalPaginas)
        {
            string textoFooter = $"Página {numeroPagina} de {totalPaginas}";
            gfx.DrawString(textoFooter, _fontSmall, _grayColor,
                new XRect(0, page.Height - 30, page.Width, 20),
                XStringFormats.TopCenter);

            // Línea separadora

         
            var gray = ((XSolidBrush)_grayColor).Color;
            gfx.DrawLine(new XPen(gray, 0.5), 40, page.Height - 35,
            page.Width - 40, page.Height - 35);
        }

        private void DibujarSeccionInformacionBasica(
           XGraphics gfx,
           PdfPage page,
           TicketExportData datos,
           ref double yPos,
           double margenIzq,
           double ancho)
        {
            var ticket = datos.Ticket;

            // 1) Título de sección
            gfx.DrawString("INFORMACIÓN BÁSICA",
                           _fontSubtitle,
                           _primaryColor,
                           margenIzq,
                           yPos);
            yPos += 25;

            // 2) Preparo cada fila con etiqueta/valor en doble columna
            double halfWidth = ancho / 2;
            double padding = 5;
            double lineSpacing = 8;

            var rows = new List<(string Lab1, string Val1, string Lab2, string Val2)>
    {
        ("Cliente:", $"{ticket.ClienteCreador?.Apellido}, {ticket.ClienteCreador?.Nombre}",
         "Creado por:", $"{ticket.ClienteCreador?.Apellido}, {ticket.ClienteCreador?.Nombre}"),

        ("Departamento:", ticket.ClienteCreador?.Departamento?.Nombre ?? "N/A",
         "Ubicación:", ticket.ClienteCreador?.Direccion ?? "N/A"),

        ("Categoría:", ticket.Categoria?.Nombre ?? "N/A",
         "Tipo:", ticket.Categoria?.tipoCategoria.ToString() ?? "N/A"),

        ("Prioridad:", datos.NombrePrioridadActual ?? "N/A",
         "Estado:", ticket.Estado?.Nombre ?? "N/A"),

        ("Fecha creación:", ticket.FechaCreacion.ToString("dd/MM/yyyy HH:mm"),
         "Última modificación:", ticket.FechaUltimaModif.ToString("dd/MM/yyyy HH:mm"))
    };

            // 3) Dibujo cada fila
            foreach (var (lab1, val1, lab2, val2) in rows)
            {
                double rowStartY = yPos;

                // — Columna IZQUIERDA —
                var sizeLab1 = gfx.MeasureString(lab1, _fontHeader);
                gfx.DrawString(lab1, _fontHeader, XBrushes.Black, margenIzq, rowStartY);

                double xVal1 = margenIzq + sizeLab1.Width + padding;
                double maxW1 = halfWidth - (sizeLab1.Width + padding);
                double yTmp1 = rowStartY;
                DibujarTextoMultilinea(gfx, val1, xVal1, ref yTmp1, _fontNormal, maxW1);
                double h1 = yTmp1 - rowStartY;

                // — Columna DERECHA —
                var sizeLab2 = gfx.MeasureString(lab2, _fontHeader);
                double col2X = margenIzq + halfWidth;
                gfx.DrawString(lab2, _fontHeader, XBrushes.Black, col2X, rowStartY);

                double xVal2 = col2X + sizeLab2.Width + padding;
                double maxW2 = halfWidth - (sizeLab2.Width + padding);
                double yTmp2 = rowStartY;
                DibujarTextoMultilinea(gfx, val2, xVal2, ref yTmp2, _fontNormal, maxW2);
                double h2 = yTmp2 - rowStartY;

                // 4) Avanzo Y por la mayor altura
                double rowHeight = Math.Max(h1, h2);
                yPos += rowHeight + lineSpacing;
            }

            // 5) Margen extra al final
            yPos += 10;
        }


        private void DibujarSeccionAsuntoDescripcion(XGraphics gfx, PdfPage page, Ticket ticket,
            ref double yPos, double margenIzq, double ancho)
        {
            // Asunto
            gfx.DrawString("ASUNTO", _fontSubtitle, _primaryColor, margenIzq, yPos);
            yPos += 20;

            DibujarTextoMultilinea(gfx, ticket.Asunto ?? "Sin asunto",
                margenIzq, ref yPos, _fontNormal, ancho);

            yPos += 20;

            // Descripción
            gfx.DrawString("DESCRIPCIÓN", _fontSubtitle, _primaryColor, margenIzq, yPos);
            yPos += 20;

            DibujarTextoMultilinea(gfx, ticket.Descripcion ?? "Sin descripción",
                margenIzq, ref yPos, _fontNormal, ancho);

            yPos += 20;
        }

        // ── UPDATE de DibujarSeccionCamposPersonalizados ─────────────────────────
        // ── UPDATE completo de DibujarSeccionCamposPersonalizados ────────────────
        // ── UPDATE de DibujarSeccionCamposPersonalizados ─────────────────────────
        private void DibujarSeccionCamposPersonalizados(
            XGraphics gfx,
            PdfPage page,
            TicketExportData datos,
            ref double yPos,
            double margenIzq,
            double ancho)
        {
            // 1) Título
            gfx.DrawString("CAMPOS PERSONALIZADOS", _fontSubtitle, _primaryColor, margenIzq, yPos);
            yPos += 25;

            if (datos.CamposPersonalizados == null ||
                datos.DefinicionesCampos == null ||
                datos.CamposPersonalizados.Count == 0)
            {
                yPos += 10;
                return;
            }

            // 2) Lista de (etiqueta, valor)
            var items = datos.CamposPersonalizados
                .Where(v => datos.DefinicionesCampos.ContainsKey(v.DefinicionCampoPersonalizadoId))
                .Select(v =>
                {
                    var def = datos.DefinicionesCampos[v.DefinicionCampoPersonalizadoId];
                    return (Label: def.Etiqueta + ":", Value: ObtenerTextoValor(def, v));
                })
                .ToList();

            // 3) Configuración de la doble columna
            double halfWidth = ancho / 2;
            double padding = 5;  // espacio entre etiqueta y valor
            double lineSpacing = 8;  // espacio entre filas

            // 4) Recorro de dos en dos
            for (int i = 0; i < items.Count; i += 2)
            {
                double rowStartY = yPos;
                double hLeft = 0, hRight = 0;

                // ── Columna IZQUIERDA ───────────────────────────────────────────────
                {
                    var (lab, val) = items[i];
                    double colX = margenIzq;
                    double colW = halfWidth;

                    // Mido tamaños
                    var sizeLab = gfx.MeasureString(lab, _fontHeader);
                    var sizeVal = gfx.MeasureString(val, _fontNormal);
                    double xVal = colX + sizeLab.Width + padding;

                    // Si cabe todo en la misma línea
                    if (sizeLab.Width + padding + sizeVal.Width <= colW)
                    {
                        gfx.DrawString(lab, _fontHeader, XBrushes.Black, colX, rowStartY);
                        gfx.DrawString(val, _fontNormal, XBrushes.Black, xVal, rowStartY);
                        hLeft = Math.Max(sizeLab.Height, sizeVal.Height);
                    }
                    else
                    {
                        // Sino, etiqueta + wrap
                        double yTemp = rowStartY;
                        DibujarTextoMultilinea(gfx, lab, colX, ref yTemp, _fontHeader, colW);
                        // valor indentado
                        DibujarTextoMultilinea(gfx, val, colX + padding, ref yTemp, _fontNormal, colW - padding);
                        hLeft = yTemp - rowStartY;
                    }
                }

                // ── Columna DERECHA ────────────────────────────────────────────────
                if (i + 1 < items.Count)
                {
                    var (lab2, val2) = items[i + 1];
                    double colX2 = margenIzq + halfWidth;
                    double colW2 = halfWidth;

                    var sizeLab2 = gfx.MeasureString(lab2, _fontHeader);
                    var sizeVal2 = gfx.MeasureString(val2, _fontNormal);
                    double xVal2 = colX2 + sizeLab2.Width + padding;

                    if (sizeLab2.Width + padding + sizeVal2.Width <= colW2)
                    {
                        gfx.DrawString(lab2, _fontHeader, XBrushes.Black, colX2, rowStartY);
                        gfx.DrawString(val2, _fontNormal, XBrushes.Black, xVal2, rowStartY);
                        hRight = Math.Max(sizeLab2.Height, sizeVal2.Height);
                    }
                    else
                    {
                        double yTemp2 = rowStartY;
                        DibujarTextoMultilinea(gfx, lab2, colX2, ref yTemp2, _fontHeader, colW2);
                        DibujarTextoMultilinea(gfx, val2, colX2 + padding, ref yTemp2, _fontNormal, colW2 - padding);
                        hRight = yTemp2 - rowStartY;
                    }
                }

                // 5) Avanzo Y por la fila más alta + spacing
                yPos += Math.Max(hLeft, hRight) + lineSpacing;
            }

            // 6) Margen final
            yPos += 10;
        }


        private void DibujarSeccionHistorial(
            XGraphics gfx,
            PdfPage page,
            PdfDocument document,
            TicketExportData datos,
            ref double yPos,
            double margenIzq,
            double ancho)
        {
            gfx.DrawString("HISTORIAL DE CAMBIOS", _fontSubtitle, _primaryColor, margenIzq, yPos);
            yPos += 25;

            double col1 = margenIzq, col2 = margenIzq + 100, col3 = margenIzq + 250;
            gfx.DrawString("Fecha", _fontHeader, XBrushes.Black, col1, yPos);
            gfx.DrawString("Usuario", _fontHeader, XBrushes.Black, col2, yPos);
            gfx.DrawString("Acción", _fontHeader, XBrushes.Black, col3, yPos);
            yPos += 10;

            foreach (var h in datos.Historial.OrderBy(x => x.FechaCambio))
            {
                // Ya no paginamos aquí; ExportarTicket ya forzó página nueva
                string usr = datos.UsuariosNombres.TryGetValue(h.UsuarioCambioId, out var n) ? n : "Desconocido";

                gfx.DrawString(h.FechaCambio.ToString("dd/MM/yy HH:mm"),
                               _fontSmall, XBrushes.Black, col1, yPos);
                gfx.DrawString(usr,
                               _fontSmall, XBrushes.Black, col2, yPos);

                string accion = ObtenerTextoAccion(h, datos);
                DibujarTextoMultilinea(
                    gfx,
                    accion,
                    col3,
                    ref yPos,
                    _fontSmall,
                    ancho - (col3 - margenIzq)
                );
                yPos += 5;
            }
        }

        // ── NUEVA función DibujarComentario ────────────────────────────────────
        private void DibujarComentario(
            XGraphics gfx,
            PdfPage page,
            PdfDocument document,
            Comentario comentario,
            ref double yPos,
            double margenIzq,
            double ancho,
            int nivel)
        {
            // Si ya no cabe, crea página nueva
            if (yPos > page.Height - 100)
            {
                page = document.AddPage();
                page.Size = PageSize.A4;
                gfx = XGraphics.FromPdfPage(page);
                yPos = 40;
            }

            double indentacion = margenIzq + (nivel * 20);
            double anchoDisponible = ancho - (nivel * 20);

            // Fondo del comentario de primer nivel
            if (nivel == 0)
            {
                var rect = new XRect(indentacion - 5, yPos - 5, anchoDisponible + 10, 50);
                gfx.DrawRectangle(new XSolidBrush(XColor.FromArgb(250, 250, 250)), rect);
                gfx.DrawRectangle(new XPen(XColor.FromArgb(220, 220, 220), 1), rect);
            }

            // Header con nombre y fecha
            string header = $"{comentario.Usuario.Nombre} {comentario.Usuario.Apellido} - {comentario.Fecha:dd/MM/yyyy HH:mm}";
            gfx.DrawString(header, _fontHeader, _primaryColor, indentacion, yPos);
            yPos += 15;

            // Texto del comentario, con word-wrap
            DibujarTextoMultilinea(gfx, comentario.Texto, indentacion, ref yPos, _fontNormal, anchoDisponible);
            yPos += 10;

            // Dibujar respuestas anidadas
            foreach (var respuesta in comentario.Respuestas)
            {
                DibujarComentario(
                    gfx,
                    page,
                    document,
                    respuesta,
                    ref yPos,
                    margenIzq,
                    ancho,
                    nivel + 1
                );
            }
        }

        private void DibujarSeccionComentarios(
           XGraphics gfx,
           PdfPage page,
           PdfDocument document,
           List<Comentario> comentarios,
           ref double yPos,
           double margenIzq,
           double ancho)
        {
            gfx.DrawString("COMENTARIOS", _fontSubtitle, _primaryColor, margenIzq, yPos);
            yPos += 25;

            foreach (var comentario in comentarios.OrderBy(c => c.Fecha))
            {
                // Ya no paginamos aquí; ExportarTicket ya forzó página nueva
                DibujarComentario(
                    gfx,
                    page,
                    document,
                    comentario,
                    ref yPos,
                    margenIzq,
                    ancho,
                    0
                );
            }
        }

        private void DibujarCampoValor(XGraphics gfx, string campo, string valor,
            double x, ref double y, double anchoMax)
        {
            gfx.DrawString(campo, _fontHeader, XBrushes.Black, x, y);
            gfx.DrawString(valor, _fontNormal, XBrushes.Black, x + 120, y);
            y += 20;
        }

        private void DibujarTextoMultilinea(XGraphics gfx, string texto, double x,
            ref double y, XFont font, double anchoMax)
        {
            if (string.IsNullOrEmpty(texto)) return;

            var palabras = texto.Split(' ');
            var linea = "";

            foreach (var palabra in palabras)
            {
                var lineaPrueba = string.IsNullOrEmpty(linea) ? palabra : linea + " " + palabra;
                var tamaño = gfx.MeasureString(lineaPrueba, font);

                if (tamaño.Width > anchoMax && !string.IsNullOrEmpty(linea))
                {
                    gfx.DrawString(linea, font, XBrushes.Black, x, y);
                    y += font.Height + 2;
                    linea = palabra;
                }
                else
                {
                    linea = lineaPrueba;
                }
            }

            if (!string.IsNullOrEmpty(linea))
            {
                gfx.DrawString(linea, font, XBrushes.Black, x, y);
                y += font.Height + 2;
            }
        }

        private string ObtenerTextoValor(DefinicionCampoPersonalizado def, ValorCampoTicket valor)
        {
            switch (def.TipoDato)
            {
                case TipoDatoCampo.Texto:
                    return valor.ValorTexto ?? "";
                case TipoDatoCampo.Numero:
                    return (valor.ValorNumero ?? 0).ToString();
                case TipoDatoCampo.Fecha:
                    return valor.ValorFecha?.ToString("dd/MM/yyyy") ?? "";
                case TipoDatoCampo.Lista:
                    return valor.ValorTexto ?? "";
                default:
                    return valor.ValorTexto ?? "";
            }
        }

        private string ObtenerTextoAccion(TicketHistorico h, TicketExportData datos)
        {
            switch (h.TipoEvento)
            {
                case "Prioridad":
                    string antesP = h.ValorAnteriorId.HasValue && datos.PrioridadesNombres.ContainsKey(h.ValorAnteriorId.Value)
                        ? datos.PrioridadesNombres[h.ValorAnteriorId.Value] : "—";
                    string nuevaP = h.ValorNuevoId.HasValue && datos.PrioridadesNombres.ContainsKey(h.ValorNuevoId.Value)
                        ? datos.PrioridadesNombres[h.ValorNuevoId.Value] : "—";
                    return $"Prioridad: {antesP} → {nuevaP}";

                case "Categoría":
                    string antesC = h.ValorAnteriorId.HasValue && datos.CategoriasNombres.ContainsKey(h.ValorAnteriorId.Value)
                        ? datos.CategoriasNombres[h.ValorAnteriorId.Value] : "—";
                    string nuevaC = h.ValorNuevoId.HasValue && datos.CategoriasNombres.ContainsKey(h.ValorNuevoId.Value)
                        ? datos.CategoriasNombres[h.ValorNuevoId.Value] : "—";
                    return $"Categoría: {antesC} → {nuevaC}";

                case "Estado":
                    string antesE = h.ValorAnteriorId.HasValue && datos.EstadosNombres.ContainsKey(h.ValorAnteriorId.Value)
                        ? datos.EstadosNombres[h.ValorAnteriorId.Value] : "—";
                    string nuevoE = h.ValorNuevoId.HasValue && datos.EstadosNombres.ContainsKey(h.ValorNuevoId.Value)
                        ? datos.EstadosNombres[h.ValorNuevoId.Value] : "—";
                    return $"Estado: {antesE} → {nuevoE}";

                default:
                    return h.TipoEvento + (string.IsNullOrEmpty(h.Comentario) ? "" : ": " + h.Comentario);
            }
        }

        /// <summary>
        /// Exporta múltiples tickets en un solo PDF
        /// </summary>
        public bool ExportarMultiplesTickets(List<TicketExportData> tickets, string rutaArchivo)
        {
            try
            {
                PdfDocument document = new PdfDocument();
                document.Info.Title = $"Exportación de {tickets.Count} tickets";

                foreach (var ticketData in tickets)
                {
                    PdfPage page = document.AddPage();
                    XGraphics gfx = XGraphics.FromPdfPage(page);
                    double yPosition = 40;

                    // Versión simplificada para múltiples tickets
                    DibujarHeader(gfx, page, ticketData.Ticket, ref yPosition);
                    DibujarSeccionInformacionBasica(gfx, page, ticketData, ref yPosition, 40, page.Width - 80);
                    DibujarSeccionAsuntoDescripcion(gfx, page, ticketData.Ticket, ref yPosition, 40, page.Width - 80);
                }

                document.Save(rutaArchivo);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al exportar múltiples tickets: {ex.Message}", ex);
            }
        }
    }
}