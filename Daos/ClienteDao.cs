using RepairHouse.Dtos.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepairHouse.Daos
{
    public class ClienteDao
    {
        public List<ClienteItemTablaDto> traerTodos()
        {
            // momentaneamente lo haremos asi, aca deberia de ir la consulta de la conexión
            List<ClienteItemTablaDto> empleados = new List<ClienteItemTablaDto>();
            empleados.Add(new ClienteItemTablaDto(11, "William Alexander Landaverde Hernandez", "12345678-9", "2211-3344"));
            empleados.Add(new ClienteItemTablaDto(22, "Kenya Beatriz Castellanos Gonzalez", "12345678-9", "2211-3344"));
            empleados.Add(new ClienteItemTablaDto(88, "Bill Alfonso Quezada Gates", "12345678-9", "2211-3344"));
            empleados.Add(new ClienteItemTablaDto(33, "William William William William", "12345678-9", "2211-3344"));
            empleados.Add(new ClienteItemTablaDto(88, "Alexander Alexander Alexander Alexander", "12345678-9", "2211-3344"));
            empleados.Add(new ClienteItemTablaDto(88, "Landaverde Landaverde Landaverde Landaverde", "12345678-9", "2211-3344"));
            empleados.Add(new ClienteItemTablaDto(88, "Hernandez Hernandez Hernandez Hernandez", "12345678-9", "2211-3344"));
            empleados.Add(new ClienteItemTablaDto(88, "Kenya Kenya Kenya Kenya", "12345678-9", "2211-3344"));
            empleados.Add(new ClienteItemTablaDto(88, "Beatriz Beatriz Beatriz Beatriz", "12345678-9", "2211-3344"));
            empleados.Add(new ClienteItemTablaDto(88, "Castellanos Castellanos Castellanos Castellanos", "12345678-9", "2211-3344"));
            empleados.Add(new ClienteItemTablaDto(88, "Gonzalez Gonzalez Gonzalez Gonzalez", "12345678-9", "2211-3344"));
            empleados.Add(new ClienteItemTablaDto(88, "Bill Bill Bill Bill", "12345678-9", "2211-3344"));
            empleados.Add(new ClienteItemTablaDto(88, "Alfonso Alfonso Alfonso Alfonso", "12345678-9", "2211-3344"));
            empleados.Add(new ClienteItemTablaDto(88, "Quezada Quezada Quezada Quezada", "12345678-9", "2211-3344"));
            empleados.Add(new ClienteItemTablaDto(88, "Gates Gates Gates Gates", "12345678-9", "2211-3344"));

            return empleados;
        }
    }
}