using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto.Entidade
{
    public class Id
    {
        private static long referencia = Convert.ToInt64(190101 * Math.Pow(10, 10));

        public static long NewId()
        {
            Thread.Sleep(new Random().Next(10,100));
            return Convert.ToInt64(DateTime.Now.ToString("yyMMddHHmmssffff")) - referencia;
        }

        public static bool IsEmpty(long id)
        {
            return id == 0;
        }
    }
}
