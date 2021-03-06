﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupBy_Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            var clientes = new List<Clientes>()
            {
                new Clientes(){Id=1, Name="Pedro", Phone=11},
                new Clientes(){Id=2, Name="Juan", Phone=22},
                new Clientes(){Id=3, Name="Alberto", Phone=33},
                new Clientes(){Id=4, Name="Jennifer", Phone=44},
            };
            var facturas = new List<Facturas>() 
            {
                new Facturas(){IdFactura=1,Data=new DateTime(2016,01,01), IdCliente=1, Importe=1000},
                new Facturas(){IdFactura=2,Data=new DateTime(2016,01,02), IdCliente=1, Importe=2000},
                new Facturas(){IdFactura=3,Data=new DateTime(2016,01,03), IdCliente=2, Importe=3000},
                new Facturas(){IdFactura=4,Data=new DateTime(2016,01,04), IdCliente=3, Importe=4000},
            };
            var query = from f in facturas
                        join c in clientes on f.IdCliente equals c.Id
                        group f by new { c.Name} into lista
                        select new { Name=lista.Key.Name, Cont=lista.Count(), Suma=lista.Sum(list=>list.Importe) };
            
            foreach (var grupo in query)
            {

                Console.WriteLine("Nombre Cliente:" + grupo.Name+" "+ "Número facturas: "+ grupo.Cont+" "+"Importe:"+ grupo.Suma+ Environment.NewLine);

            } Console.ReadLine();
        }
    }
}
