/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://indivo.org/vocab/xml/documents#")]
public partial class CodedValue {
    
    private string typeField;
    
    private string valueField;
    
    private string abbrevField;
    
    private string valueField1;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="anyURI")]
    public string type {
        get {
            return this.typeField;
        }
        set {
            this.typeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string abbrev {
        get {
            return this.abbrevField;
        }
        set {
            this.abbrevField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value {
        get {
            return this.valueField1;
        }
        set {
            this.valueField1 = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://indivo.org/vocab/xml/documents#")]
public partial class Range {
    
    private double minimumField;
    
    private bool minimumFieldSpecified;
    
    private double maximumField;
    
    private bool maximumFieldSpecified;
    
    private CodedValue unitField;
    
    /// <remarks/>
    public double minimum {
        get {
            return this.minimumField;
        }
        set {
            this.minimumField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool minimumSpecified {
        get {
            return this.minimumFieldSpecified;
        }
        set {
            this.minimumFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double maximum {
        get {
            return this.maximumField;
        }
        set {
            this.maximumField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool maximumSpecified {
        get {
            return this.maximumFieldSpecified;
        }
        set {
            this.maximumFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public CodedValue unit {
        get {
            return this.unitField;
        }
        set {
            this.unitField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://indivo.org/vocab/xml/documents#")]
public partial class ValueAndUnit {
    
    private double valueField;
    
    private bool valueFieldSpecified;
    
    private string textValueField;
    
    private CodedValue unitField;
    
    /// <remarks/>
    public double value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool valueSpecified {
        get {
            return this.valueFieldSpecified;
        }
        set {
            this.valueFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public string textValue {
        get {
            return this.textValueField;
        }
        set {
            this.textValueField = value;
        }
    }
    
    /// <remarks/>
    public CodedValue unit {
        get {
            return this.unitField;
        }
        set {
            this.unitField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlIncludeAttribute(typeof(Concentration))]
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://indivo.org/vocab/xml/documents#")]
public partial class ValueOrRange {
    
    private object itemField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("range", typeof(Range))]
    [System.Xml.Serialization.XmlElementAttribute("value", typeof(ValueAndUnit))]
    public object Item {
        get {
            return this.itemField;
        }
        set {
            this.itemField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlIncludeAttribute(typeof(ResultInSet))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(ResultInRange))]
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://indivo.org/vocab/xml/documents#")]
public abstract partial class Result {
    
    private CodedValue flagField;
    
    /// <remarks/>
    public CodedValue flag {
        get {
            return this.flagField;
        }
        set {
            this.flagField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://indivo.org/vocab/xml/documents#")]
public partial class ResultInSet : Result {
    
    private string valueField;
    
    private ResultInSetOption[] optionField;
    
    /// <remarks/>
    public string value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("option")]
    public ResultInSetOption[] option {
        get {
            return this.optionField;
        }
        set {
            this.optionField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://indivo.org/vocab/xml/documents#")]
public partial class ResultInSetOption {
    
    private bool normalField;
    
    private string descriptionField;
    
    private string valueField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool normal {
        get {
            return this.normalField;
        }
        set {
            this.normalField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string description {
        get {
            return this.descriptionField;
        }
        set {
            this.descriptionField = value;
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
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://indivo.org/vocab/xml/documents#")]
public partial class ResultInRange : Result {
    
    private ValueAndUnit valueAndUnitField;
    
    private Range normalRangeField;
    
    private Range nonCriticalRangeField;
    
    /// <remarks/>
    public ValueAndUnit valueAndUnit {
        get {
            return this.valueAndUnitField;
        }
        set {
            this.valueAndUnitField = value;
        }
    }
    
    /// <remarks/>
    public Range normalRange {
        get {
            return this.normalRangeField;
        }
        set {
            this.normalRangeField = value;
        }
    }
    
    /// <remarks/>
    public Range nonCriticalRange {
        get {
            return this.nonCriticalRangeField;
        }
        set {
            this.nonCriticalRangeField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://indivo.org/vocab/xml/documents#")]
public partial class Concentration : ValueOrRange {
}

