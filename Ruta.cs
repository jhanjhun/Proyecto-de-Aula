public class Ruta
    {
        public string IdRuta { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public List<string> Estaciones { get; set; }
        public int[,] MatrizDistancias { get; set; }

        public Ruta(string idRuta, string origen, string destino, List<string> estaciones, int[,] matrizDistancias)
        {
            IdRuta = idRuta;
            Origen = origen;
            Destino = destino;
            Estaciones = estaciones;
            MatrizDistancias = matrizDistancias;
        }
        public List<string> RecomendarRuta()
        {
            int n = Estaciones.Count;
            int origenIdx = Estaciones.IndexOf(Origen);
            int destinoIdx = Estaciones.IndexOf(Destino);

            int[] dist = new int[n];
            bool[] visitado = new bool[n];
            int[] padre = new int[n];

            for (int i = 0; i < n; i++)
            {
                dist[i] = int.MaxValue;
                visitado[i] = false;
                padre[i] = -1;
            }
            dist[origenIdx] = 0;

            // Algoritmo Dijkstra
            for (int count = 0; count < n - 1; count++)
            {
                int u = -1;
                int min = int.MaxValue;
                for (int i = 0; i < n; i++)
                {
                    if (!visitado[i] && dist[i] < min)
                    {
                        min = dist[i];
                        u = i;
                    }
                }
                if (u == -1) break;
                visitado[u] = true;

                for (int v = 0; v < n; v++)
                {
                    int peso = MatrizDistancias[u, v];
                    if (!visitado[v] && peso > 0 && dist[u] != int.MaxValue && dist[u] + peso < dist[v])
                    {
                        dist[v] = dist[u] + peso;
                        padre[v] = u;
                    }
                }
            }

            List<int> caminoIdx = new List<int>();
            int paso = destinoIdx;
            while (paso != -1)
            {
                caminoIdx.Add(paso);
                paso = padre[paso];
            }
            caminoIdx.Reverse();

            List<string> rutaRecomendada = new List<string>();
            foreach (int idx in caminoIdx)
                rutaRecomendada.Add(Estaciones[idx]);

            return rutaRecomendada;
        }

        public void ModificarRuta(List<string> nuevasEstaciones, int[,] nuevaMatriz)
        {
            Estaciones = nuevasEstaciones;
            MatrizDistancias = nuevaMatriz;
        }
    }
