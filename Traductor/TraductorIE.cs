using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diccionario_DDi.Traductor
{
    class TraductorIE
    {
        string entrada;
        string salida;

        public string Entrada { get => entrada; set => entrada = value; }
        public string Salida { get => salida; set => salida = value; }

        public string[] español = { "agua", "fuego", "amor", "aire", "sol", "luna", "evaluar", "rabia","disminuir", "enfado","voluntad", "informe", "ubicación", "etiqueta", "personalizar", "diagnosticando", "manteniendo", "instalamdo", "cliente", "lanzado", "proporcionar", "suministros", "horrible" };
        public string[] inglés = { "water", "fire", "love", "air", "sun", "moon", "assess", "rage", "diminish", "anger", "willingness", "report", "location", "tag", "customize", "diagnosing", "maintaining", "installing", "client", "launched", "provide", "supplies", "ghastly" };


        public string Traduceme()
        {
            bool encontrar = false;
            int cont = 0;
            while (encontrar == false)
            {
                if (entrada == inglés[cont])
                {
                    salida = español[cont];
                    encontrar = true;
                }
                cont++;
            }
            return salida;
        }
    }
}
