 using BE;
using BE.Composite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BE
{
    public class Familia : Componente
    {
        private IList<Componente> _hijos;
        public Familia()
        {
            _hijos = new List<Componente>();
        }

        public override List<Componente> Hijos
        {
            get
            {
                return _hijos.ToList();
            }

        }

        public override void VaciarHijos()
        {
            _hijos.Clear();
        }

        public override void AgregarHijo(Componente c)
        {

            // validaciones :

            /*
             * 1.- No se puede agregar un componente nulo. OK
             * 2.- No se puede agregar una familia que forme un ciclo recursivo.
             * 3.- No se puede agregar una familia que ya exista en el nivel actual.
             * 4.- No se puede agregar una patente que ya exista en el nivel actual.
             * 5.- No se puede agregar una familia que ya exista en la familia actual.
             * 6- No se puede agregar una patente que ya exista en la familia actual.
             * 7.- No se puede agregar una familia que ya exista en la familia actual.
             * 
             * 
             */
            if (c == null)
                throw new ArgumentNullException(nameof(c), "No se puede agregar un componente nulo.");

            // Si el hijo es una Familia, aplica lógica de "evitar recursividad en cualquier nivel"
            if (c is Familia nuevaFamilia)
            {
                // 1) Verificar ciclo recursivo de familias (todo el árbol)
                if (EsCicloFamilia(nuevaFamilia))
                    throw new Exception("No se puede agregar la familia: formaría una recursividad.");

                // 2) Verificar duplicado en este mismo nivel
                if (ValidarSiExisteEnNivelActual(nuevaFamilia))
                    throw new Exception("Ya existe esta familia en el nivel actual.");

                // OK, agregar
                _hijos.Add(nuevaFamilia);
            }
            else if (c is Patente nuevaPatente)
            {
                // Para Patentes, NO recorremos la jerarquía completa. 
                // Queremos permitir la misma patente en niveles diferentes. 
                // Solo impedimos que se duplique en este mismo nivel.
                if (ValidarSiExisteEnNivelActual(nuevaPatente))
                    throw new Exception("La patente ya existe en este nivel.");

                _hijos.Add(nuevaPatente);
            }
            else
            {
                // Si existiera otro tipo de componente, manejalo en un else, 
                // o lanza excepción si no lo soportas.
                throw new Exception("Tipo de componente desconocido");
            }
        }

        private bool ValidarSiExisteEnNivelActual(Componente c)
        {
            if (c.Id == this.Id)
                return true;
            foreach (var hijo in _hijos)
            {
                if (hijo.Id == c.Id)
                    return true;
            }
            return false;
        }


        private bool EsCicloFamilia(Familia nuevaFamilia)
        {
            var visitados = new HashSet<int>();
            return EsCicloRecursivo(this, nuevaFamilia, visitados);
        }

        private bool EsCicloRecursivo(Familia actual, Familia nueva, HashSet<int> visitados)
        {
            // Caso base: si comparten Id => ciclo
            if (actual.Id == nueva.Id)
                return true;

            visitados.Add(actual.Id);

            foreach (var hijo in actual._hijos)
            {
                // Verificar si uno de los hijos es la nueva familia
                if (hijo.Id == nueva.Id)
                    return true;

                // Si el hijo es otra Familia y no se ha visitado, recursion
                if (hijo is Familia famHijo && !visitados.Contains(famHijo.Id))
                {
                    if (EsCicloRecursivo(famHijo, nueva, visitados))
                        return true;
                }
            }

            return false;
        }


        public void AgregarHijoFamilyRaiz(Componente c)
        {
            if (c == null)
            {
                throw new ArgumentNullException(nameof(c), "No se puede agregar un componente nulo.");
            }

            if (ValidarSiExiste(c))
            {
                throw new ArgumentNullException(nameof(c), "No se puede agregar esta patente porque ya existe en la familia.");
                //return;
            }

            _hijos.Add(c);
        }

        public bool ValidarSiExiste(Componente c)
        {
            if (c.Id == this.Id)
                return true;

            foreach (var hijo in _hijos)
            {
                if (hijo.Id == c.Id)
                    return true;
            }

            return false;
        }

        public bool EsCiclo(Componente c)
        {
            var visitados = new HashSet<int>();
            return EsCicloRecursivo(this, c, visitados);
        }

        private bool EsCicloRecursivo(Familia actual, Componente nuevo, HashSet<int> visitados)
        {
            if (nuevo.Id == actual.Id) return true;

            visitados.Add(actual.Id);

            foreach (var hijo in actual._hijos)
            {
                if (hijo.Id == nuevo.Id) return true;

                if (hijo is Familia familia && !visitados.Contains(familia.Id))
                {
                    if (EsCicloRecursivo(familia, nuevo, visitados))
                        return true;
                }
            }

            return false;
        }

        public override void EliminarHijo(Componente c)
        {
            _hijos.Remove(c);
        }

    }
}

