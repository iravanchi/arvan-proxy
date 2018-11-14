using System;
using System.Net.Http;
using Arvan.Proxy.Authorization;
using Arvan.Proxy.Products;

namespace Arvan.Proxy
{
    public class ArvanClient
    {
        private readonly ArvanProxyInternalData _internalData;

        #region Initialization

        public ArvanClient()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://napi.arvancloud.com/");

            _internalData = new ArvanProxyInternalData
            {
                ClientInstance = this,
                Settings = new ArvanClientSettings(),
                HttpClient = httpClient
            };

            InitializeClients();
        }

        public ArvanClient(RequestAuthorizationBase authorization) : this()
        {
            _internalData.Settings.RequestAuthorization = authorization;
        }

        private void InitializeClients()
        {
            Cdn = new CdnProxy(_internalData);
            Dns = new DnsProxy(_internalData);
            IaaS = new IaaSProxy(_internalData);
            Live = new LiveProxy(_internalData);
            Security = new SecurityProxy(_internalData);
            Storage = new StorageProxy(_internalData);
            Vod = new VodProxy(_internalData);
        }

        #endregion

        public ArvanClientSettings Settings => _internalData.Settings;
        
        public CdnProxy Cdn { get; private set; }
        public DnsProxy Dns { get; private set; }
        public IaaSProxy IaaS { get; private set; }
        public LiveProxy Live { get; private set; }
        public SecurityProxy Security { get; private set; }
        public StorageProxy Storage { get; private set; }
        public VodProxy Vod { get; private set; }
    }
}