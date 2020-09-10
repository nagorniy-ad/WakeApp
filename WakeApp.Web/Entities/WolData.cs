using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.NetworkInformation;
using WakeApp.Core;
using WakeApp.Web.Extensions;

namespace WakeApp.Web
{
    public class WolData : IValidatableObject
    {
        public string MacAddress { get; set; }
        public string IpAddress { get; set; }
        public string SubnetMask { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            if (string.IsNullOrWhiteSpace(MacAddress))
            {
                errors.Add(new ValidationResult(
                    errorMessage: "MAC-адрес удаленной конечной точки не задан.",
                    memberNames: new string[] { "macAddress" }));
            }
            else
            {
                if (MacAddress.IsValidMacAddress() == false)
                {
                    errors.Add(new ValidationResult(
                        errorMessage: "MAC-адрес удаленной конечной точки некорректен.",
                        memberNames: new string[] { "macAddress" }));
                }
            }
            if (string.IsNullOrWhiteSpace(IpAddress) == false)
            {
                if (IpAddress.IsValidIpAddress() == false)
                {
                    errors.Add(new ValidationResult(
                        errorMessage: "IP-адрес удаленной конечной точки некорректен.",
                        memberNames: new string[] { "ipAddress" }));
                }
                if (string.IsNullOrWhiteSpace(SubnetMask))
                {
                    errors.Add(new ValidationResult(
                        errorMessage: "Маска подсети удаленной конечной точки не задана.",
                        memberNames: new string[] { "subnetMask" }));
                }
                else
                {
                    if (SubnetMask.IsValidIpAddress() == false)
                    {
                        errors.Add(new ValidationResult(
                            errorMessage: "Маска подсети удаленной конечной точки некорректна.",
                            memberNames: new string[] { "subnetMask" }));
                    }
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(SubnetMask) == false)
                {
                    errors.Add(new ValidationResult(
                        errorMessage: "IP-адрес удаленной конечной точки не задан.",
                        memberNames: new string[] { "ipAddress" }));
                    if (SubnetMask.IsValidIpAddress() == false)
                    {
                        errors.Add(new ValidationResult(
                            errorMessage: "Маска подсети удаленной конечной точки некорректна.",
                            memberNames: new string[] { "subnetMask" }));
                    }
                }
            }
            return errors;
        }

        public IRemoteEndPoint ToRemoteEndPoint()
        {
            return string.IsNullOrWhiteSpace(IpAddress) == false && string.IsNullOrWhiteSpace(SubnetMask) ?
                new RemoteEndPoint(macAddress: PhysicalAddress.Parse(MacAddress.ToUpper()), ipAddress: IPAddress.Parse(IpAddress), subnetMask: IPAddress.Parse(SubnetMask)) :
                new RemoteEndPoint(macAddress: PhysicalAddress.Parse(MacAddress.ToUpper()));
        }
    }
}
