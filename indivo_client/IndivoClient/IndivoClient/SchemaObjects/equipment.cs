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
public partial class Equipment {
    
    private System.DateTime dateStartedField;
    
    private bool dateStartedFieldSpecified;
    
    private System.DateTime dateStoppedField;
    
    private bool dateStoppedFieldSpecified;
    
    private string typeField;
    
    private string nameField;
    
    private string vendorField;
    
    private string idField;
    
    private string descriptionField;
    
    private string specificationField;
    
    private string certificationField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
    public System.DateTime dateStarted {
        get {
            return this.dateStartedField;
        }
        set {
            this.dateStartedField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool dateStartedSpecified {
        get {
            return this.dateStartedFieldSpecified;
        }
        set {
            this.dateStartedFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
    public System.DateTime dateStopped {
        get {
            return this.dateStoppedField;
        }
        set {
            this.dateStoppedField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool dateStoppedSpecified {
        get {
            return this.dateStoppedFieldSpecified;
        }
        set {
            this.dateStoppedFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public string type {
        get {
            return this.typeField;
        }
        set {
            this.typeField = value;
        }
    }
    
    /// <remarks/>
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    public string vendor {
        get {
            return this.vendorField;
        }
        set {
            this.vendorField = value;
        }
    }
    
    /// <remarks/>
    public string id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
    
    /// <remarks/>
    public string description {
        get {
            return this.descriptionField;
        }
        set {
            this.descriptionField = value;
        }
    }
    
    /// <remarks/>
    public string specification {
        get {
            return this.specificationField;
        }
        set {
            this.specificationField = value;
        }
    }
    
    /// <remarks/>
    public string certification {
        get {
            return this.certificationField;
        }
        set {
            this.certificationField = value;
        }
    }
}