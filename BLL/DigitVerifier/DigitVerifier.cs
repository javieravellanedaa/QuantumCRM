using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using INTERFACES;

namespace BLL.DigitVerifier
{
    /// <summary>
    /// Clase genérica que calcula el DVH y DVV para cualquier entidad IDigitVerificable.
    /// </summary>
    public class DigitVerifier<T>
        where T : class, IDigitVerificable
    {
        private readonly PropertyInfo[] _props;

        public DigitVerifier()
        {
            _props = typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p =>
                    p.Name != nameof(IDigitVerificable.DigitoVerificadorH)
                    && (!p.PropertyType.IsGenericType
                        || p.PropertyType.GetGenericTypeDefinition() != typeof(List<>))
                )
                // Mantiene el orden declarado en la clase
                .OrderBy(p => p.MetadataToken)
                .ToArray();
        }

        /// <summary>
        /// Calcula el DVH según: sum(carácter * posCarácter * posAtributo) % 97, formateado D2.
        /// </summary>
        public string ComputeDVH(T entity)
        {
            long sum = 0;
            for (int ai = 0; ai < _props.Length; ai++)
            {
                var s = _props[ai].GetValue(entity)?.ToString() ?? "";
                for (int ci = 0; ci < s.Length; ci++)
                    sum += s[ci] * (ai + 1) * (ci + 1);
            }
            return (sum % 97).ToString("D2");
        }

        /// <summary>
        /// Calcula el DVV agragando los DVH de cada fila, ponderado por índice de fila.
        /// </summary>
        public string ComputeDVV(IEnumerable<T> entities)
        {
            long sum = 0;
            int rowIndex = 0;

            foreach (var e in entities)
            {
                rowIndex++;
                string dvh = ComputeDVH(e);
                for (int i = 0; i < dvh.Length; i++)
                    sum += (dvh[i] - '0') * (i + 1) * rowIndex;
            }

            return (sum % 97).ToString("D2");
        }
    }
}
