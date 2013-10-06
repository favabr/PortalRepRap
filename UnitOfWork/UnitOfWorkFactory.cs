using NHibernate;
using FluentNHibernate.Cfg;
using Configuration = NHibernate.Cfg.Configuration;
using PortalRepRap.Framework.UnitOfWork.Interface;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Xml;

namespace PortalRepRap.Framework.UnitOfWork
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private const string Default_HibernateConfig = "hibernate.cfg.xml";

        public object LockSessionFactory = new object();
        private ISessionFactory _sessionFactory;
        private Configuration _configuration;

        internal UnitOfWorkFactory()
        { }

        public IUnitOfWork Create()
        {
            return new UnitOfWorkImplementor(this, CreateSession());
        }

        public Configuration Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    _configuration = new Configuration();
                    string hibernateConfig = Default_HibernateConfig;
                    //if not rooted, assume path from base directory
                    if (Path.IsPathRooted(hibernateConfig) == false)
                        hibernateConfig = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, hibernateConfig);
                    if (File.Exists(hibernateConfig))
                        _configuration.Configure(new XmlTextReader(hibernateConfig));
                }
                return _configuration;
            }
        }

        public ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    lock (LockSessionFactory)
                    {
                        if (_sessionFactory == null)
                        {
                            var assemblyMapType = ConfigurationManager.AppSettings["AssemblyMappingType"];

                            if (string.IsNullOrWhiteSpace(assemblyMapType))
                                throw new InvalidOperationException("AssemblyMappingType not found, please add the AssemblyMappingType on section AppSettings in app configuration file.");

                            var fluentMappings = Assembly.Load(assemblyMapType);

                            //Configuration.AddAuxiliaryDatabaseObject(new SpatialAuxiliaryDatabaseObject(Configuration));

                            var interceptors = (NameValueCollection)ConfigurationManager.GetSection("nhibernate.interceptors");
                            if (interceptors != null)
                                foreach (string k in interceptors.AllKeys)
                                    Configuration.SetInterceptor((IInterceptor)Activator.CreateInstance(Type.GetType(interceptors[k])));

                            var cfg = Fluently.Configure(Configuration).Mappings(
                                m => m.FluentMappings
                                    .AddFromAssembly(fluentMappings));

                            _sessionFactory = cfg.BuildSessionFactory();

                        }

                        return _sessionFactory;
                    }
                }

                return _sessionFactory;
            }
        }

        public void DisposeUnitOfWork(UnitOfWorkImplementor adapter)
        {
            UnitOfWork.DisposeUnitOfWork(adapter);
        }

        private ISession CreateSession()
        {
            var session = SessionFactory.OpenSession();
            session.FlushMode = FlushMode.Commit;
            return session;
        }
    }
}
