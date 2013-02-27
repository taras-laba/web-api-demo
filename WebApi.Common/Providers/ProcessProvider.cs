using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using WebApi.Common.Models;

namespace WebApi.Common.Providers
{
    public class ProcessProvider : IProcessProvider
    {
        public IEnumerable<ProcessModel> GetAll()
        {
            return GetProcesses();
        }

        public ProcessModel GetById(int id)
        {
            return GetProcesses().SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<ProcessModel> GetByName(string name)
        {
            return GetAll().Where(p => p.Name == name);
        } 

        public void Kill(int id)
        {
            try
            {
                Process.GetProcessById(id).Kill();
            }
            catch (Exception ex)
            {
                throw new ServiceException(string.Format("can't kill process with id = {0}", id), ex);
            }
            
        }

        public void Start(string fileName)
        {
            try
            {
                Process.Start(fileName);
            }
            catch (Exception ex)
            {
                throw new ServiceException(string.Format("can't start '{0}'", fileName), ex);
            }
            
        }

        private IEnumerable<ProcessModel> GetProcesses()
        {
            var nativeProcesses = Process.GetProcesses();
            foreach (var process in nativeProcesses)
            {
                ProcessModel model = ToModel(process);
                if (model != null)
                {
                    yield return model;
                }
            }
        }

        private ProcessModel ToModel(Process process)
        {
            try
            {
                var model = new ProcessModel
                    {
                        Id = process.Id,
                        Name = process.ProcessName,
                        ProcessorTime = process.TotalProcessorTime,
                        Title = process.MainWindowTitle,
                        Icon = Icon.ExtractAssociatedIcon(process.MainModule.FileName)
                    };

                return model;
            }
            catch
            {
                return null;
            }
        }
    }
}