using System;
using Microsoft.AspNetCore.Mvc;

namespace Arnet.Libraries.AttributesLibrary
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RemoteServerAttribute : RemoteAttribute
    {
        public RemoteServerAttribute(string routeName) : base(routeName)
        {
        }

        public RemoteServerAttribute(string action, string controller) : base(action, controller)
        {
        }

        public RemoteServerAttribute(string action, string controller, string areaName) : base(action, controller, areaName)
        {
        }

        protected RemoteServerAttribute()
        {
        }

        public override bool IsValid(object value)
        {
           
            return base.IsValid(value);
        }
    }
}
