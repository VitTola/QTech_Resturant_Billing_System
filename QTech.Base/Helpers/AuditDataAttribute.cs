using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base.Helpers
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public class AuditDataAttribute : Attribute
    {
        string _resourceName;
        int _index;
        bool _isIgnored;

        /// <summary>
        /// Data for Audit
        /// </summary>
        /// <param name="resourceName">Resource name to keep during trackig - null for same attribute column.</param>
        /// <param name="index">Tracking order to display to auditrail page.</param>
        public AuditDataAttribute(string resourceName = null, int index = 0,bool Ignored = false)
        {
            _resourceName = resourceName;
            _index = index;
            _isIgnored = Ignored;
        }
        public string ResourceName => _resourceName;
        public int Index => _index;
        public bool Ignored => _isIgnored;
    }

    [System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class AuditGroupDataAttribute : Attribute
    {
        string _resourceName;
        public AuditGroupDataAttribute(string resourceName)
        {
            _resourceName = resourceName;
        }
        public string ResourceName => _resourceName;
    }
}
