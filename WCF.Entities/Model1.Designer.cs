﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]

namespace WCF.Entities
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class AgentesCVCEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new AgentesCVCEntities object using the connection string found in the 'AgentesCVCEntities' section of the application configuration file.
        /// </summary>
        public AgentesCVCEntities() : base("name=AgentesCVCEntities", "AgentesCVCEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new AgentesCVCEntities object.
        /// </summary>
        public AgentesCVCEntities(string connectionString) : base(connectionString, "AgentesCVCEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new AgentesCVCEntities object.
        /// </summary>
        public AgentesCVCEntities(EntityConnection connection) : base(connection, "AgentesCVCEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<EmpresaEntity> EmpresaEntity
        {
            get
            {
                if ((_EmpresaEntity == null))
                {
                    _EmpresaEntity = base.CreateObjectSet<EmpresaEntity>("EmpresaEntity");
                }
                return _EmpresaEntity;
            }
        }
        private ObjectSet<EmpresaEntity> _EmpresaEntity;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the EmpresaEntity EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToEmpresaEntity(EmpresaEntity empresaEntity)
        {
            base.AddObject("EmpresaEntity", empresaEntity);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="AgentesCVCModel", Name="EmpresaEntity")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class EmpresaEntity : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new EmpresaEntity object.
        /// </summary>
        /// <param name="idEmpresa">Initial value of the idEmpresa property.</param>
        public static EmpresaEntity CreateEmpresaEntity(global::System.Int32 idEmpresa)
        {
            EmpresaEntity empresaEntity = new EmpresaEntity();
            empresaEntity.idEmpresa = idEmpresa;
            return empresaEntity;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 idEmpresa
        {
            get
            {
                return _idEmpresa;
            }
            set
            {
                if (_idEmpresa != value)
                {
                    OnidEmpresaChanging(value);
                    ReportPropertyChanging("idEmpresa");
                    _idEmpresa = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("idEmpresa");
                    OnidEmpresaChanged();
                }
            }
        }
        private global::System.Int32 _idEmpresa;
        partial void OnidEmpresaChanging(global::System.Int32 value);
        partial void OnidEmpresaChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String nome
        {
            get
            {
                return _nome;
            }
            set
            {
                OnnomeChanging(value);
                ReportPropertyChanging("nome");
                _nome = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("nome");
                OnnomeChanged();
            }
        }
        private global::System.String _nome;
        partial void OnnomeChanging(global::System.String value);
        partial void OnnomeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String codigo
        {
            get
            {
                return _codigo;
            }
            set
            {
                OncodigoChanging(value);
                ReportPropertyChanging("codigo");
                _codigo = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("codigo");
                OncodigoChanged();
            }
        }
        private global::System.String _codigo;
        partial void OncodigoChanging(global::System.String value);
        partial void OncodigoChanged();

        #endregion
    
    }

    #endregion
    
}
