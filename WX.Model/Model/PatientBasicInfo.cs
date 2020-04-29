using System;
using System.Collections.Generic;
using System.Text;

namespace WX.Model.Model
{
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    //[System.Xml.Serialization.]
    public class Request
    {

        public string System { get; set; }
        public string SecurityCode { get; set; }
        public PatientBasicInfo PatientInfo { get; set; }
    }

    [System.Xml.Serialization.XmlType(AnonymousType =true)]
    public partial class PatientBasicInfo
    {
        public string PatientNo { get; set; }
        public string PatientName { get; set; }
        public string Phoneticize { get; set; }
        public string Sex { get; set; }
        public string Birth { get; set; }
        public string BirthPlace { get; set; }
        public string Country { get; set; }
        public string Nation { get; set; }
        public string IDNumber { get; set; }
        public string SecurityNo { get; set; }
        public string Workunits { get; set; }
        public string Address { get; set; }
        public string ZIPCode { get; set; }
        public string Phone { get; set; }
        public string ContactPerson { get; set; }
        public string ContactShip { get; set; }
        public string ContactPersonAdd { get; set; }
        public string ContactPersonPhone { get; set; }
        public string OperationCode { get; set; }
        public string OperationName { get; set; }
        public string OperationTime { get; set; }
        public string CardNo { get; set; }
        public string ChangeType { get; set; }

    }

    partial class A 
    {
        
    }

    partial class A
    {
    
    }
}
