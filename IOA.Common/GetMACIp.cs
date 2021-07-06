using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace IOA.Common
{
    /// <summary>
    /// 获取电脑物理地址【IP和MAC】
    /// </summary>
    public static class GetMACIp
    {
        /// <summary>
        /// 获取本地Ip地址
        /// </summary>
        /// <returns></returns>
        public static string GetLocalIp()
        {
            var addressList = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList;
            var ips = addressList.Where(address => address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    .Select(address => address.ToString()).ToArray();
            if (ips.Length == 1)
            {
                return ips.First();
            }
            return ips.Where(address => !address.EndsWith(".1")).FirstOrDefault() ?? ips.FirstOrDefault();
        }


        /// <summary>
        /// 获取电脑 MAC（物理） 地址
        /// </summary>
        /// <returns></returns>
        public static string GetMAC()
        {
            //本地计算机网络连接信息
            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            //获取本机所有网络连接
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

            //获取本机电脑名
            var HostName = computerProperties.HostName;
            //获取域名
            var DomainName = computerProperties.DomainName;

            if (nics == null || nics.Length < 1)
            {
                return "";
            }

            var MACIp = "";
            foreach (NetworkInterface adapter in nics)
            {
                var adapterName = adapter.Name;

                var adapterDescription = adapter.Description;
                var NetworkInterfaceType = adapter.NetworkInterfaceType;
                if (adapterName == "本地连接* 1")
                {
                    PhysicalAddress address = adapter.GetPhysicalAddress();
                    byte[] bytes = address.GetAddressBytes();

                    for (int i = 0; i < bytes.Length; i++)
                    {
                        MACIp += bytes[i].ToString("X2");

                        if (i != bytes.Length - 1)
                        {
                            MACIp += "-";
                        }
                    }
                }
            }

            return MACIp;

        }


    }
}
