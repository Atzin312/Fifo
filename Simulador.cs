using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIFO
{
	class Simulador
	{
		private static Random rand;
		Queue<Proceso> filaSimulacion;
		private int procesosAten, ciclosVa, restantes, sumaRestantes;

		public Simulador()
		{
			rand = new Random();
			filaSimulacion = new Queue<Proceso>();
		}

		public String simular()
		{
			procesosAten = 0;
			ciclosVa = 0;
			sumaRestantes = 0;
			for (int i = 0; i < 200; i++)
			{
				if (rand.Next(1,5)==3)
				{
					Proceso p = new Proceso(rand.Next(4,15));
					filaSimulacion.Enqueue(p);
				}
				if (filaSimulacion.Count!=0)
				{
					filaSimulacion.Peek().ciclos--;
					if (filaSimulacion.Peek().ciclos==0)
					{
						filaSimulacion.Dequeue();
						procesosAten++;
					}
				}
				else
				{
					ciclosVa++;
				}
			}
			restantes = filaSimulacion.Count;
			while (filaSimulacion.Count!=0)
			{
				sumaRestantes+= filaSimulacion.Dequeue().ciclos;
			}
			return "Procesos atendidos: " + procesosAten + Environment.NewLine + "Ciclos vacios: " + ciclosVa + Environment.NewLine + "Procesos faltantes: " + restantes + Environment.NewLine + "Suma restantes: " + sumaRestantes;
		}
	}
}
