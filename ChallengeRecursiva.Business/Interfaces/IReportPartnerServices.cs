using ChallengeRecursiva.DataAccess.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeRecursiva.Business.Interfaces
{
    public interface IReportPartnerServices
    {
        //Cantidad total de personas registradas.
        Task<int> Exercise1();
        //El promedio de edad de los socios de Racing.
        Task<int> Exercise2();
        //Un listado con las 100 primeras personas casadas, con estudios 
        //Universitarios, ordenadas de menor a mayor según su edad.Por
        //cada persona, mostrar: nombre, edad y equipo.
        Task<List<Partner>> Exercise3();
        //Un listado con los 5 nombres más comunes entre los hinchas de River.
        Task<List<string>> Exercise4();

        //Un listado, ordenado de mayor a menor según la cantidad de 
        //socios, que enumere, junto con cada equipo, el promedio de edad
        //de sus socios, la menor edad registrada y la mayor edad registrada.
        Task<List<Partner>> Exercise5();

    }
}
