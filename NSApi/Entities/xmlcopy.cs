
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class Storingen
{

    private StoringenStoring[] ongeplandField;

    private StoringenGepland geplandField;

    public Storingen()
    {
        
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Storing", IsNullable = false)]
    public StoringenStoring[] Ongepland
    {
        get
        {
            return this.ongeplandField;
        }
        set
        {
            this.ongeplandField = value;
        }
    }

    /// <remarks/>
    public StoringenGepland Gepland
    {
        get
        {
            return this.geplandField;
        }
        set
        {
            this.geplandField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class StoringenStoring
{

    private string idField;

    private string trajectField;

    private string redenField;

    private string berichtField;

    private string datumField;

    /// <remarks/>
    public string id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    public string Traject
    {
        get
        {
            return this.trajectField;
        }
        set
        {
            this.trajectField = value;
        }
    }

    /// <remarks/>
    public string Reden
    {
        get
        {
            return this.redenField;
        }
        set
        {
            this.redenField = value;
        }
    }

    /// <remarks/>
    public string Bericht
    {
        get
        {
            return this.berichtField;
        }
        set
        {
            this.berichtField = value;
        }
    }

    /// <remarks/>
    public string Datum
    {
        get
        {
            return this.datumField;
        }
        set
        {
            this.datumField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class StoringenGepland
{

    private StoringenGeplandStoring storingField;

    /// <remarks/>
    public StoringenGeplandStoring Storing
    {
        get
        {
            return this.storingField;
        }
        set
        {
            this.storingField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class StoringenGeplandStoring
{

    private string idField;

    private string trajectField;

    private string periodeField;

    private string adviesField;

    private string berichtField;

    private string oorzaakField;

    private string vertragingField;

    /// <remarks/>
    public string id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    public string Traject
    {
        get
        {
            return this.trajectField;
        }
        set
        {
            this.trajectField = value;
        }
    }

    /// <remarks/>
    public string Periode
    {
        get
        {
            return this.periodeField;
        }
        set
        {
            this.periodeField = value;
        }
    }

    /// <remarks/>
    public string Advies
    {
        get
        {
            return this.adviesField;
        }
        set
        {
            this.adviesField = value;
        }
    }

    /// <remarks/>
    public string Bericht
    {
        get
        {
            return this.berichtField;
        }
        set
        {
            this.berichtField = value;
        }
    }

    /// <remarks/>
    public string Oorzaak
    {
        get
        {
            return this.oorzaakField;
        }
        set
        {
            this.oorzaakField = value;
        }
    }

    /// <remarks/>
    public string Vertraging
    {
        get
        {
            return this.vertragingField;
        }
        set
        {
            this.vertragingField = value;
        }
    }
}

