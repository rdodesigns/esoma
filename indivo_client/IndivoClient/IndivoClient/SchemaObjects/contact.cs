﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=4.0.30319.1.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://indivo.org/vocab/xml/documents#")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://indivo.org/vocab/xml/documents#", IsNullable=false)]
public partial class Contact {
    
    private ContactName nameField;
    
    private ContactEmail[] emailField;
    
    private ContactAddress[] addressField;
    
    private ContactLocation[] locationField;
    
    private ContactPhoneNumber[] phoneNumberField;
    
    private ContactInstantMessengerName[] instantMessengerNameField;
    
    private string thumbnailField;
    
    /// <remarks/>
    public ContactName name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("email")]
    public ContactEmail[] email {
        get {
            return this.emailField;
        }
        set {
            this.emailField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("address")]
    public ContactAddress[] address {
        get {
            return this.addressField;
        }
        set {
            this.addressField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("location")]
    public ContactLocation[] location {
        get {
            return this.locationField;
        }
        set {
            this.locationField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("phoneNumber")]
    public ContactPhoneNumber[] phoneNumber {
        get {
            return this.phoneNumberField;
        }
        set {
            this.phoneNumberField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("instantMessengerName")]
    public ContactInstantMessengerName[] instantMessengerName {
        get {
            return this.instantMessengerNameField;
        }
        set {
            this.instantMessengerNameField = value;
        }
    }
    
    /// <remarks/>
    public string thumbnail {
        get {
            return this.thumbnailField;
        }
        set {
            this.thumbnailField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://indivo.org/vocab/xml/documents#")]
public partial class ContactName {
    
    private string fullNameField;
    
    private string[] givenNameField;
    
    private string familyNameField;
    
    /// <remarks/>
    public string fullName {
        get {
            return this.fullNameField;
        }
        set {
            this.fullNameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("givenName")]
    public string[] givenName {
        get {
            return this.givenNameField;
        }
        set {
            this.givenNameField = value;
        }
    }
    
    /// <remarks/>
    public string familyName {
        get {
            return this.familyNameField;
        }
        set {
            this.familyNameField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://indivo.org/vocab/xml/documents#")]
public partial class ContactEmail {
    
    private string typeField;
    
    private string valueField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string type {
        get {
            return this.typeField;
        }
        set {
            this.typeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://indivo.org/vocab/xml/documents#")]
public partial class ContactAddress {
    
    private string streetAddressField;
    
    private string postalCodeField;
    
    private string localityField;
    
    private string regionField;
    
    private string countryField;
    
    private string timeZoneField;
    
    private string typeField;
    
    /// <remarks/>
    public string streetAddress {
        get {
            return this.streetAddressField;
        }
        set {
            this.streetAddressField = value;
        }
    }
    
    /// <remarks/>
    public string postalCode {
        get {
            return this.postalCodeField;
        }
        set {
            this.postalCodeField = value;
        }
    }
    
    /// <remarks/>
    public string locality {
        get {
            return this.localityField;
        }
        set {
            this.localityField = value;
        }
    }
    
    /// <remarks/>
    public string region {
        get {
            return this.regionField;
        }
        set {
            this.regionField = value;
        }
    }
    
    /// <remarks/>
    public string country {
        get {
            return this.countryField;
        }
        set {
            this.countryField = value;
        }
    }
    
    /// <remarks/>
    public string timeZone {
        get {
            return this.timeZoneField;
        }
        set {
            this.timeZoneField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string type {
        get {
            return this.typeField;
        }
        set {
            this.typeField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://indivo.org/vocab/xml/documents#")]
public partial class ContactLocation {
    
    private string latitudeField;
    
    private string longitudeField;
    
    private string typeField;
    
    /// <remarks/>
    public string latitude {
        get {
            return this.latitudeField;
        }
        set {
            this.latitudeField = value;
        }
    }
    
    /// <remarks/>
    public string longitude {
        get {
            return this.longitudeField;
        }
        set {
            this.longitudeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string type {
        get {
            return this.typeField;
        }
        set {
            this.typeField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://indivo.org/vocab/xml/documents#")]
public partial class ContactPhoneNumber {
    
    private string typeField;
    
    private string valueField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string type {
        get {
            return this.typeField;
        }
        set {
            this.typeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://indivo.org/vocab/xml/documents#")]
public partial class ContactInstantMessengerName {
    
    private string protocolField;
    
    private string valueField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string protocol {
        get {
            return this.protocolField;
        }
        set {
            this.protocolField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}