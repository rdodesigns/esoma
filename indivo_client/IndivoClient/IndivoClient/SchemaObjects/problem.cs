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
public partial class Problem {
    
    private System.DateTime dateOnsetField;
    
    private bool dateOnsetFieldSpecified;
    
    private System.DateTime dateResolutionField;
    
    private bool dateResolutionFieldSpecified;
    
    private CodedValue nameField;
    
    private string commentsField;
    
    private string diagnosedByField;
    
    /// <remarks/>
    public System.DateTime dateOnset {
        get {
            return this.dateOnsetField;
        }
        set {
            this.dateOnsetField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool dateOnsetSpecified {
        get {
            return this.dateOnsetFieldSpecified;
        }
        set {
            this.dateOnsetFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public System.DateTime dateResolution {
        get {
            return this.dateResolutionField;
        }
        set {
            this.dateResolutionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool dateResolutionSpecified {
        get {
            return this.dateResolutionFieldSpecified;
        }
        set {
            this.dateResolutionFieldSpecified = value;
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
    public string comments {
        get {
            return this.commentsField;
        }
        set {
            this.commentsField = value;
        }
    }
    
    /// <remarks/>
    public string diagnosedBy {
        get {
            return this.diagnosedByField;
        }
        set {
            this.diagnosedByField = value;
        }
    }
}

