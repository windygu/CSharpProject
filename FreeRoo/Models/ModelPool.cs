using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Compilation;
using System.Reflection;

namespace FreeRoo
{
    /// <summary>
    /// 模型池
    /// </summary>
    public class ModelPool
    {
        public static ModelPool Default { get; set; }

        private Dictionary<string, Type> models;
        public ModelPool()
        {
            this.models = new Dictionary<string, Type>();
            foreach(var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach(var type in assembly.GetTypes())
                {
                    this.models[type.FullName]= type;
                }
            }
        }
        public Type GetModel(string name)
        {
            if (this.models.ContainsKey(name))
                return this.models[name];
            return null;
        }
    }
}
