using System;
using System.Data;
using System.Xml;

namespace DAL
{
    public interface IEmployee
    {
        System.Data.DataTable GetEmployees ();
    }
}

