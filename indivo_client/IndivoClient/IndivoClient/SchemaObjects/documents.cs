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
public partial class Procedure {
    
    private System.DateTime datePerformedField;
    
    private bool datePerformedFieldSpecified;
    
    private CodedValue nameField;
    
    private Provider providerField;
    
    private string locationField;
    
    private string commentsField;
    
    /// <remarks/>
    public System.DateTime datePerformed {
        get {
            return this.datePerformedField;
        }
        set {
            this.datePerformedField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool datePerformedSpecified {
        get {
            return this.datePerformedFieldSpecified;
        }
        set {
            this.datePerformedFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public CodedValue name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    public Provider provider {
        get {
            return this.providerField;
        }
        set {
            this.providerField = value;
        }
    }
    
    /// <remarks/>
    public string location {
        get {
            return this.locationField;
        }
        set {
            this.locationField = value;
        }
    }
    
    /// <remarks/>
    public string comments {
        get {
            return this.commentsField;
        }
        set {
            this.commentsField = value;
        }
    }
}