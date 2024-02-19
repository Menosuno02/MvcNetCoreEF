using MvcNetCoreEF.Data;
using MvcNetCoreEF.Models;

namespace MvcNetCoreEF.Repositories
{
    public class RepositoryEmpleados
    {
        private HospitalContext context;

        public RepositoryEmpleados(HospitalContext context)
        {
            this.context = context;
        }

        public List<string> GetOficios()
        {
            var consulta = (from datos in this.context.Empleados
                            select datos.Oficio).Distinct();
            return consulta.ToList();
        }

        public List<Empleado> GetEmpleadosOficio(string oficio)
        {
            var consulta = from datos in this.context.Empleados
                           where datos.Oficio == oficio
                           select datos;
            return consulta.ToList();
        }

        // Método para incrementar salario por oficio y devolverá
        // model con empleados y resumen
        public ModelEmpleados IncrementarSalarioOficio
            (int incremento, string oficio)
        {
            List<Empleado> empleadosOficio = this.GetEmpleadosOficio(oficio);
            foreach (Empleado emp in empleadosOficio)
            {
                emp.Salario += incremento;
            }
            this.context.SaveChanges();
            int sumSalarial = empleadosOficio.Sum(x => x.Salario);
            double mediaSalarial = empleadosOficio.Average(x => x.Salario);
            ModelEmpleados model = new ModelEmpleados
            {
                Empleados = empleadosOficio,
                SumaSalarial = sumSalarial,
                MediaSalarial = mediaSalarial
            };
            return model;
        }
    }
}
