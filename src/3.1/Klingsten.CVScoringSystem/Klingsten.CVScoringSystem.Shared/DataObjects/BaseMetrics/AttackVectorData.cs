using Klingsten.CVScoringSystem.Shared.DomainObjects;

namespace Klingsten.CVScoringSystem.Shared.DataObjects.BaseMetrics;

public class AttackVectorData
{
    public static Metric Get()
    {
        var variables = new List<MetricVariable>
        {
            new() {Name = "Network", Vector = "N", Descricption = "The vulnerable component is bound to the network stack and the set of possible attackers extends beyond the other options listed below, up to and including the entire Internet. Such a vulnerability is often termed “remotely exploitable” and can be thought of as an attack being exploitable at the protocol level one or more network hops away (e.g., across one or more routers). An example of a network attack is an attacker causing a denial of service (DoS) by sending a specially crafted TCP packet across a wide area network (e.g., CVE‑2004‑0230)." },
            new() {Name = "Adjacent", Vector = "A", Descricption = "The vulnerable component is bound to the network stack, but the attack is limited at the protocol level to a logically adjacent topology. This can mean an attack must be launched from the same shared physical (e.g., Bluetooth or IEEE 802.11) or logical (e.g., local IP subnet) network, or from within a secure or otherwise limited administrative domain (e.g., MPLS, secure VPN to an administrative network zone). One example of an Adjacent attack would be an ARP (IPv4) or neighbor discovery (IPv6) flood leading to a denial of service on the local LAN segment (e.g., CVE‑2013‑6014)." },
            new() {Name = "Local", Vector = "L", Descricption = "The vulnerable component is not bound to the network stack and the attacker’s path is via read/write/execute capabilities. Either:<br/>the attacker exploits the vulnerability by accessing the target system locally(e.g., keyboard, console), or remotely(e.g., SSH);<br/>or the attacker relies on User Interaction by another person to perform actions required to exploit the vulnerability(e.g., using social engineering techniques to trick a legitimate user into opening a malicious document)." },
            new() {Name = "Physical", Vector = "P", Descricption = "The attack requires the attacker to physically touch or manipulate the vulnerable component. Physical interaction may be brief (e.g., evil maid attack[^1]) or persistent. An example of such an attack is a cold boot attack in which an attacker gains access to disk encryption keys after physically accessing the target system. Other examples include peripheral attacks via FireWire/USB Direct Memory Access (DMA)." }
        };
        var metric = new Metric
        {
            Name = "Attack Vector",
            Vector = "AV",
            Descricption = "This metric reflects the context by which vulnerability exploitation is possible. This metric value (and consequently the Base Score) will be larger the more remote (logically, and physically) an attacker can be in order to exploit the vulnerable component. The assumption is that the number of potential attackers for a vulnerability that could be exploited from across a network is larger than the number of potential attackers that could exploit a vulnerability requiring physical access to a device, and therefore warrants a greater Base Score.",
            Guidance = "When deciding between Network and Adjacent, if an attack can be launched over a wide area network or from outside the logically adjacent administrative network domain, use Network. Network should be used even if the attacker is required to be on the same intranet to exploit the vulnerable system (e.g., the attacker can only exploit the vulnerability from inside a corporate network).",
            Variables = variables
        };
        return metric;
    }
}