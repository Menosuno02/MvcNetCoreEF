using Microsoft.AspNetCore.Mvc;
using MvcNetCoreEF.Data;
using MvcNetCoreEF.Models;

namespace MvcNetCoreEF.Repositories
{
    public class RepositoryHospital
    {
        // La clase repo siempre recibirá el Context
        // mediante inyeccción de dependencias
        private HospitalContext context;

        public RepositoryHospital(HospitalContext context)
        {
            this.context = context;
        }

        public List<Hospital> GetHospitales()
        {
            var consulta = from datos in this.context.Hospitales
                           select datos;
            return consulta.ToList();
        }

        public Hospital FindHospital(int idHospital)
        {
            var consulta = from datos in this.context.Hospitales
                           where datos.HospitalCod == idHospital
                           select datos;

            // Tenemos un método que devuelve el primer registro
            // o el valor por defecto del model
            return consulta.FirstOrDefault();
        }

        public void InsertHospital(Hospital hospital)
        {
            this.context.Hospitales.Add(hospital);
            this.context.SaveChanges();
        }

        public void DeleteHospital(int idHospital)
        {
            Hospital hospital = this.FindHospital(idHospital);
            this.context.Hospitales.Remove(hospital);
            this.context.SaveChanges();
        }

        public void UpdateHospital(int id, string nombre, string direccion, string telefono, int camas)
        {
            Hospital hospital = this.FindHospital(id);
            hospital.HospitalCod = id;
            hospital.Nombre = nombre;
            hospital.Direccion = direccion;
            hospital.Telefono = telefono;
            hospital.NumCamas = camas;
            this.context.SaveChanges();
        }

    }
}
