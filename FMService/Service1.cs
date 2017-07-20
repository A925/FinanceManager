using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace FMService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Addlog("Сервис копирования файла запущен");
        }

        protected override void OnStop()
        {
            Addlog("Сервис копирования файла остановлен");
        }

        public void Addlog(string log)
        {
            if(!System.Diagnostics.EventLog.SourceExists("FMService"))
                EventLog.CreateEventSource("FMService", "FMServece");

        }
    }
}
