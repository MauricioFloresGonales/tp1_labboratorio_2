using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Taller
    {
        List<Vehiculo> vehiculos;
        int espacioDisponible;
        public enum ETipo
        {
            Ciclomotor, Sedan, SUV, Todos
        }

        #region "Constructores"
        private Taller()
        {
            this.vehiculos = new List<Vehiculo>();
        }
        public Taller(int espacioDisponible):this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Listar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="taller">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public string Listar(Taller taller, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", taller.vehiculos.Count, taller.espacioDisponible);
            sb.AppendLine("");
            foreach (Vehiculo v in taller.vehiculos)
            {
                if(TipoSegunTamanio(v,tipo))
                {
                    switch (tipo)
                    {
                        case ETipo.SUV:
                            sb.AppendLine(v.Mostrar());
                            break;
                        case ETipo.Ciclomotor:
                            sb.AppendLine(v.Mostrar());
                            break;
                        case ETipo.Sedan:
                            sb.AppendLine(v.Mostrar());
                            break;
                        default:
                            sb.AppendLine(v.Mostrar());
                            break;
                    }
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// Compara el tamanio del vehiculo con el tipo que se solicita ya en esta aplicacion
        /// los Ciclomotores son simpre pequeños
        /// los Sedan son sipre medianos y
        /// los SUV son simpre grandes
        /// </summary>
        /// <param name="vehiculo"> Elemento a comparar el tamanio</param>
        /// <param name="tipo">Tipos de ítems de la lista que se va a comparar</param>
        /// <returns>true si se encontro su tipo de lo contrario false</returns>
        public static bool TipoSegunTamanio(Vehiculo vehiculo, ETipo tipo)
        {
            bool retorno = false;
            switch (tipo)
            {
                case ETipo.Ciclomotor:
                    if (vehiculo.Tamanio == Vehiculo.ETamanio.Chico)
                        retorno = true;
                    break;
                case ETipo.Sedan:
                    if (vehiculo.Tamanio == Vehiculo.ETamanio.Mediano)
                        retorno = true;
                    break;
                case ETipo.SUV:
                    if (vehiculo.Tamanio == Vehiculo.ETamanio.Grande)
                        retorno = true;
                    break;
                case ETipo.Todos:
                    retorno = true;
                    break;
                default:
                    retorno = false;
                    break;
            }
            return retorno;
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="taller">Objeto donde se agregará el elemento</param>
        /// <param name="vehiculo">Objeto a agregar</param>
        /// <returns></returns>
        public static Taller operator +(Taller taller, Vehiculo vehiculo)
        {
            foreach (Vehiculo v in taller.vehiculos)
            {
                if (v == vehiculo)
                    return taller;
            }
            
            if (taller.espacioDisponible > taller.vehiculos.Count())
            {
                taller.vehiculos.Add(vehiculo);
            }
            return taller;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="taller">Objeto donde se quitará el elemento</param>
        /// <param name="vehiculo">Objeto a quitar</param>
        /// <returns></returns>
        public static Taller operator -(Taller taller, Vehiculo vehiculo)
        {
            foreach (Vehiculo v in taller.vehiculos)
            {
                if (v == vehiculo)
                {
                    taller.vehiculos.Remove(vehiculo);
                    break;
                }
            }
            return taller; ;
        }
        #endregion
    }
}
