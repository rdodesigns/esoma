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
using System.Collections.Generic;

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
public partial class ExerciseResult {
    public ExerciseResult()
	{
		exerciseGroupsField = new List<ExerciseResultExerciseGroup>();
	}
	
    private string totalAdherenceEvaluationField;
    
    private List<ExerciseResultExerciseGroup> exerciseGroupsField;
    
    /// <remarks/>
    public string totalAdherenceEvaluation {
        get {
            return this.totalAdherenceEvaluationField;
        }
        set {
            this.totalAdherenceEvaluationField = value;
        }
    }
    
    /// <remarks/>
public List<ExerciseResultExerciseGroup> exerciseGroups {
        get {
            return this.exerciseGroupsField;
        }
        set {
            this.exerciseGroupsField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://indivo.org/vocab/xml/documents#")]
public partial class ExerciseResultExerciseGroup {
    public ExerciseResultExerciseGroup()
	{
		exercisesField = new List<ExerciseResultExerciseGroupExercise>();
	}
	
    private int setsField;
    
    private bool setsFieldSpecified;
    
    private string daysOfWeekField;
    
    private List<ExerciseResultExerciseGroupExercise> exercisesField;
    
    /// <remarks/>
    public int sets {
        get {
            return this.setsField;
        }
        set {
            this.setsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool setsSpecified {
        get {
            return this.setsFieldSpecified;
        }
        set {
            this.setsFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public string daysOfWeek {
        get {
            return this.daysOfWeekField;
        }
        set {
            this.daysOfWeekField = value;
        }
    }
    
    /// <remarks/>
    public List<ExerciseResultExerciseGroupExercise> exercises {
        get {
            return this.exercisesField;
        }
        set {
            this.exercisesField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://indivo.org/vocab/xml/documents#")]
public partial class ExerciseResultExerciseGroupExercise {
    public ExerciseResultExerciseGroupExercise()
	{
		activityField = new ExerciseResultExerciseGroupExerciseActivity();
		resistanceField = new ExerciseResultExerciseGroupExerciseResistance();
		distanceField = new ExerciseResultExerciseGroupExerciseDistance();
		additionalDetailsField = new ExerciseResultExerciseGroupExerciseAdditionalDetails();
	}
	
    private string adherenceEvaluationField;
    
    private ExerciseResultExerciseGroupExerciseActivity activityField;
    
    private System.DateTime startTimeField;
    
    private int durationField;
    
    private int setsField;
    
    private bool setsFieldSpecified;
    
    private int repititionsField;
    
    private bool repititionsFieldSpecified;
    
    private ExerciseResultExerciseGroupExerciseResistance resistanceField;
    
    private ExerciseResultExerciseGroupExerciseDistance distanceField;
    
    private ExerciseResultExerciseGroupExerciseAdditionalDetails additionalDetailsField;
    
    /// <remarks/>
    public string adherenceEvaluation {
        get {
            return this.adherenceEvaluationField;
        }
        set {
            this.adherenceEvaluationField = value;
        }
    }
    
    /// <remarks/>
    public ExerciseResultExerciseGroupExerciseActivity activity {
        get {
            return this.activityField;
        }
        set {
            this.activityField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
    public System.DateTime startTime {
        get {
            return this.startTimeField;
        }
        set {
            this.startTimeField = value;
        }
    }
    
    /// <remarks/>
    public int duration {
        get {
            return this.durationField;
        }
        set {
            this.durationField = value;
        }
    }
    
    /// <remarks/>
    public int sets {
        get {
            return this.setsField;
        }
        set {
            this.setsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool setsSpecified {
        get {
            return this.setsFieldSpecified;
        }
        set {
            this.setsFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public int repititions {
        get {
            return this.repititionsField;
        }
        set {
            this.repititionsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool repititionsSpecified {
        get {
            return this.repititionsFieldSpecified;
        }
        set {
            this.repititionsFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public ExerciseResultExerciseGroupExerciseResistance resistance {
        get {
            return this.resistanceField;
        }
        set {
            this.resistanceField = value;
        }
    }
    
    /// <remarks/>
    public ExerciseResultExerciseGroupExerciseDistance distance {
        get {
            return this.distanceField;
        }
        set {
            this.distanceField = value;
        }
    }
    
    /// <remarks/>
    public ExerciseResultExerciseGroupExerciseAdditionalDetails additionalDetails {
        get {
            return this.additionalDetailsField;
        }
        set {
            this.additionalDetailsField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://indivo.org/vocab/xml/documents#")]
public partial class ExerciseResultExerciseGroupExerciseActivity {
    
    private string idField;
    
    private string typeField;
    
    private string nameField;
    
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
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://indivo.org/vocab/xml/documents#")]
public partial class ExerciseResultExerciseGroupExerciseResistance {
    
    private int valueField;
    
    private string unitOfMeasurementField;
    
    /// <remarks/>
    public int value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
    
    /// <remarks/>
    public string unitOfMeasurement {
        get {
            return this.unitOfMeasurementField;
        }
        set {
            this.unitOfMeasurementField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://indivo.org/vocab/xml/documents#")]
public partial class ExerciseResultExerciseGroupExerciseDistance {
    
    private int valueField;
    
    private string unitOfMeasurementField;
    
    /// <remarks/>
    public int value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
    
    /// <remarks/>
    public string unitOfMeasurement {
        get {
            return this.unitOfMeasurementField;
        }
        set {
            this.unitOfMeasurementField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://indivo.org/vocab/xml/documents#")]
public partial class ExerciseResultExerciseGroupExerciseAdditionalDetails {
    
    private ExerciseResultExerciseGroupExerciseAdditionalDetailsDetail detailField;
    
    /// <remarks/>
    public ExerciseResultExerciseGroupExerciseAdditionalDetailsDetail detail {
        get {
            return this.detailField;
        }
        set {
            this.detailField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://indivo.org/vocab/xml/documents#")]
public partial class ExerciseResultExerciseGroupExerciseAdditionalDetailsDetail {
    
    private string nameField;
    
    private int valueField;
    
    private string unitOfMeasurementField;
    
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
    public int value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
    
    /// <remarks/>
    public string unitOfMeasurement {
        get {
            return this.unitOfMeasurementField;
        }
        set {
            this.unitOfMeasurementField = value;
        }
    }
}