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
public partial class SchoolForm {
    
    private System.DateTime dateField;
    
    private string notesField;
    
    /// <remarks/>
    public System.DateTime date {
        get {
            return this.dateField;
        }
        set {
            this.dateField = value;
        }
    }
    
    /// <remarks/>
    public string notes {
        get {
            return this.notesField;
        }
        set {
            this.notesField = value;
        }
    }
}
