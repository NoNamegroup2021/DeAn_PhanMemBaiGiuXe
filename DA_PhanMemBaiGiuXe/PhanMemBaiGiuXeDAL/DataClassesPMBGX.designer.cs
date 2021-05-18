﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhanMemBaiGiuXeDAL
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="QL_BaiGiuXe")]
	public partial class DataClassesPMBGXDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertBangThe(BangThe instance);
    partial void UpdateBangThe(BangThe instance);
    partial void DeleteBangThe(BangThe instance);
    partial void InsertLoaiTK(LoaiTK instance);
    partial void UpdateLoaiTK(LoaiTK instance);
    partial void DeleteLoaiTK(LoaiTK instance);
    partial void InsertLogin(Login instance);
    partial void UpdateLogin(Login instance);
    partial void DeleteLogin(Login instance);
    partial void InsertNhanVien(NhanVien instance);
    partial void UpdateNhanVien(NhanVien instance);
    partial void DeleteNhanVien(NhanVien instance);
    partial void InsertQuetXe(QuetXe instance);
    partial void UpdateQuetXe(QuetXe instance);
    partial void DeleteQuetXe(QuetXe instance);
    #endregion
		
		public DataClassesPMBGXDataContext() : 
				base(global::PhanMemBaiGiuXeDAL.Properties.Settings.Default.QL_BaiGiuXeConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesPMBGXDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesPMBGXDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesPMBGXDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesPMBGXDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<BangThe> BangThes
		{
			get
			{
				return this.GetTable<BangThe>();
			}
		}
		
		public System.Data.Linq.Table<LoaiTK> LoaiTKs
		{
			get
			{
				return this.GetTable<LoaiTK>();
			}
		}
		
		public System.Data.Linq.Table<Login> Logins
		{
			get
			{
				return this.GetTable<Login>();
			}
		}
		
		public System.Data.Linq.Table<NhanVien> NhanViens
		{
			get
			{
				return this.GetTable<NhanVien>();
			}
		}
		
		public System.Data.Linq.Table<QuetXe> QuetXes
		{
			get
			{
				return this.GetTable<QuetXe>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.BangThe")]
	public partial class BangThe : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _MaThe;
		
		private bool _TinhTrang;
		
		private EntitySet<QuetXe> _QuetXes;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMaTheChanging(string value);
    partial void OnMaTheChanged();
    partial void OnTinhTrangChanging(bool value);
    partial void OnTinhTrangChanged();
    #endregion
		
		public BangThe()
		{
			this._QuetXes = new EntitySet<QuetXe>(new Action<QuetXe>(this.attach_QuetXes), new Action<QuetXe>(this.detach_QuetXes));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaThe", DbType="NVarChar(20) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string MaThe
		{
			get
			{
				return this._MaThe;
			}
			set
			{
				if ((this._MaThe != value))
				{
					this.OnMaTheChanging(value);
					this.SendPropertyChanging();
					this._MaThe = value;
					this.SendPropertyChanged("MaThe");
					this.OnMaTheChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TinhTrang", DbType="Bit NOT NULL")]
		public bool TinhTrang
		{
			get
			{
				return this._TinhTrang;
			}
			set
			{
				if ((this._TinhTrang != value))
				{
					this.OnTinhTrangChanging(value);
					this.SendPropertyChanging();
					this._TinhTrang = value;
					this.SendPropertyChanged("TinhTrang");
					this.OnTinhTrangChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="BangThe_QuetXe", Storage="_QuetXes", ThisKey="MaThe", OtherKey="IDThe")]
		public EntitySet<QuetXe> QuetXes
		{
			get
			{
				return this._QuetXes;
			}
			set
			{
				this._QuetXes.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_QuetXes(QuetXe entity)
		{
			this.SendPropertyChanging();
			entity.BangThe = this;
		}
		
		private void detach_QuetXes(QuetXe entity)
		{
			this.SendPropertyChanging();
			entity.BangThe = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.LoaiTK")]
	public partial class LoaiTK : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _MaCV;
		
		private string _TenCV;
		
		private EntitySet<Login> _Logins;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMaCVChanging(string value);
    partial void OnMaCVChanged();
    partial void OnTenCVChanging(string value);
    partial void OnTenCVChanged();
    #endregion
		
		public LoaiTK()
		{
			this._Logins = new EntitySet<Login>(new Action<Login>(this.attach_Logins), new Action<Login>(this.detach_Logins));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaCV", DbType="Char(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string MaCV
		{
			get
			{
				return this._MaCV;
			}
			set
			{
				if ((this._MaCV != value))
				{
					this.OnMaCVChanging(value);
					this.SendPropertyChanging();
					this._MaCV = value;
					this.SendPropertyChanged("MaCV");
					this.OnMaCVChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenCV", DbType="NVarChar(30)")]
		public string TenCV
		{
			get
			{
				return this._TenCV;
			}
			set
			{
				if ((this._TenCV != value))
				{
					this.OnTenCVChanging(value);
					this.SendPropertyChanging();
					this._TenCV = value;
					this.SendPropertyChanged("TenCV");
					this.OnTenCVChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="LoaiTK_Login", Storage="_Logins", ThisKey="MaCV", OtherKey="MaCV")]
		public EntitySet<Login> Logins
		{
			get
			{
				return this._Logins;
			}
			set
			{
				this._Logins.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Logins(Login entity)
		{
			this.SendPropertyChanging();
			entity.LoaiTK = this;
		}
		
		private void detach_Logins(Login entity)
		{
			this.SendPropertyChanging();
			entity.LoaiTK = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Login")]
	public partial class Login : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Username;
		
		private string _Password;
		
		private string _MaNV;
		
		private string _MaCV;
		
		private EntityRef<LoaiTK> _LoaiTK;
		
		private EntityRef<NhanVien> _NhanVien;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUsernameChanging(string value);
    partial void OnUsernameChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnMaNVChanging(string value);
    partial void OnMaNVChanged();
    partial void OnMaCVChanging(string value);
    partial void OnMaCVChanged();
    #endregion
		
		public Login()
		{
			this._LoaiTK = default(EntityRef<LoaiTK>);
			this._NhanVien = default(EntityRef<NhanVien>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Username", DbType="Char(30) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				if ((this._Username != value))
				{
					this.OnUsernameChanging(value);
					this.SendPropertyChanging();
					this._Username = value;
					this.SendPropertyChanged("Username");
					this.OnUsernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="Char(30)")]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaNV", DbType="Char(10)")]
		public string MaNV
		{
			get
			{
				return this._MaNV;
			}
			set
			{
				if ((this._MaNV != value))
				{
					if (this._NhanVien.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMaNVChanging(value);
					this.SendPropertyChanging();
					this._MaNV = value;
					this.SendPropertyChanged("MaNV");
					this.OnMaNVChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaCV", DbType="Char(10)")]
		public string MaCV
		{
			get
			{
				return this._MaCV;
			}
			set
			{
				if ((this._MaCV != value))
				{
					if (this._LoaiTK.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMaCVChanging(value);
					this.SendPropertyChanging();
					this._MaCV = value;
					this.SendPropertyChanged("MaCV");
					this.OnMaCVChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="LoaiTK_Login", Storage="_LoaiTK", ThisKey="MaCV", OtherKey="MaCV", IsForeignKey=true)]
		public LoaiTK LoaiTK
		{
			get
			{
				return this._LoaiTK.Entity;
			}
			set
			{
				LoaiTK previousValue = this._LoaiTK.Entity;
				if (((previousValue != value) 
							|| (this._LoaiTK.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._LoaiTK.Entity = null;
						previousValue.Logins.Remove(this);
					}
					this._LoaiTK.Entity = value;
					if ((value != null))
					{
						value.Logins.Add(this);
						this._MaCV = value.MaCV;
					}
					else
					{
						this._MaCV = default(string);
					}
					this.SendPropertyChanged("LoaiTK");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="NhanVien_Login", Storage="_NhanVien", ThisKey="MaNV", OtherKey="MaNV", IsForeignKey=true)]
		public NhanVien NhanVien
		{
			get
			{
				return this._NhanVien.Entity;
			}
			set
			{
				NhanVien previousValue = this._NhanVien.Entity;
				if (((previousValue != value) 
							|| (this._NhanVien.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._NhanVien.Entity = null;
						previousValue.Logins.Remove(this);
					}
					this._NhanVien.Entity = value;
					if ((value != null))
					{
						value.Logins.Add(this);
						this._MaNV = value.MaNV;
					}
					else
					{
						this._MaNV = default(string);
					}
					this.SendPropertyChanged("NhanVien");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.NhanVien")]
	public partial class NhanVien : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _MaNV;
		
		private string _HoTen;
		
		private string _GioiTinh;
		
		private string _SoCMND;
		
		private string _DiaChi;
		
		private EntitySet<Login> _Logins;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMaNVChanging(string value);
    partial void OnMaNVChanged();
    partial void OnHoTenChanging(string value);
    partial void OnHoTenChanged();
    partial void OnGioiTinhChanging(string value);
    partial void OnGioiTinhChanged();
    partial void OnSoCMNDChanging(string value);
    partial void OnSoCMNDChanged();
    partial void OnDiaChiChanging(string value);
    partial void OnDiaChiChanged();
    #endregion
		
		public NhanVien()
		{
			this._Logins = new EntitySet<Login>(new Action<Login>(this.attach_Logins), new Action<Login>(this.detach_Logins));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaNV", DbType="Char(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string MaNV
		{
			get
			{
				return this._MaNV;
			}
			set
			{
				if ((this._MaNV != value))
				{
					this.OnMaNVChanging(value);
					this.SendPropertyChanging();
					this._MaNV = value;
					this.SendPropertyChanged("MaNV");
					this.OnMaNVChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HoTen", DbType="NVarChar(50)")]
		public string HoTen
		{
			get
			{
				return this._HoTen;
			}
			set
			{
				if ((this._HoTen != value))
				{
					this.OnHoTenChanging(value);
					this.SendPropertyChanging();
					this._HoTen = value;
					this.SendPropertyChanged("HoTen");
					this.OnHoTenChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GioiTinh", DbType="Char(10)")]
		public string GioiTinh
		{
			get
			{
				return this._GioiTinh;
			}
			set
			{
				if ((this._GioiTinh != value))
				{
					this.OnGioiTinhChanging(value);
					this.SendPropertyChanging();
					this._GioiTinh = value;
					this.SendPropertyChanged("GioiTinh");
					this.OnGioiTinhChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SoCMND", DbType="Char(20)")]
		public string SoCMND
		{
			get
			{
				return this._SoCMND;
			}
			set
			{
				if ((this._SoCMND != value))
				{
					this.OnSoCMNDChanging(value);
					this.SendPropertyChanging();
					this._SoCMND = value;
					this.SendPropertyChanged("SoCMND");
					this.OnSoCMNDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DiaChi", DbType="NVarChar(100)")]
		public string DiaChi
		{
			get
			{
				return this._DiaChi;
			}
			set
			{
				if ((this._DiaChi != value))
				{
					this.OnDiaChiChanging(value);
					this.SendPropertyChanging();
					this._DiaChi = value;
					this.SendPropertyChanged("DiaChi");
					this.OnDiaChiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="NhanVien_Login", Storage="_Logins", ThisKey="MaNV", OtherKey="MaNV")]
		public EntitySet<Login> Logins
		{
			get
			{
				return this._Logins;
			}
			set
			{
				this._Logins.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Logins(Login entity)
		{
			this.SendPropertyChanging();
			entity.NhanVien = this;
		}
		
		private void detach_Logins(Login entity)
		{
			this.SendPropertyChanging();
			entity.NhanVien = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.QuetXe")]
	public partial class QuetXe : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _IDThe;
		
		private string _BIENSO;
		
		private string _AnhThe;
		
		private EntityRef<BangThe> _BangThe;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDTheChanging(string value);
    partial void OnIDTheChanged();
    partial void OnBIENSOChanging(string value);
    partial void OnBIENSOChanged();
    partial void OnAnhTheChanging(string value);
    partial void OnAnhTheChanged();
    #endregion
		
		public QuetXe()
		{
			this._BangThe = default(EntityRef<BangThe>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDThe", DbType="NVarChar(20) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string IDThe
		{
			get
			{
				return this._IDThe;
			}
			set
			{
				if ((this._IDThe != value))
				{
					if (this._BangThe.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIDTheChanging(value);
					this.SendPropertyChanging();
					this._IDThe = value;
					this.SendPropertyChanged("IDThe");
					this.OnIDTheChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BIENSO", DbType="NVarChar(11) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string BIENSO
		{
			get
			{
				return this._BIENSO;
			}
			set
			{
				if ((this._BIENSO != value))
				{
					this.OnBIENSOChanging(value);
					this.SendPropertyChanging();
					this._BIENSO = value;
					this.SendPropertyChanged("BIENSO");
					this.OnBIENSOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AnhThe", DbType="NVarChar(100)")]
		public string AnhThe
		{
			get
			{
				return this._AnhThe;
			}
			set
			{
				if ((this._AnhThe != value))
				{
					this.OnAnhTheChanging(value);
					this.SendPropertyChanging();
					this._AnhThe = value;
					this.SendPropertyChanged("AnhThe");
					this.OnAnhTheChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="BangThe_QuetXe", Storage="_BangThe", ThisKey="IDThe", OtherKey="MaThe", IsForeignKey=true)]
		public BangThe BangThe
		{
			get
			{
				return this._BangThe.Entity;
			}
			set
			{
				BangThe previousValue = this._BangThe.Entity;
				if (((previousValue != value) 
							|| (this._BangThe.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._BangThe.Entity = null;
						previousValue.QuetXes.Remove(this);
					}
					this._BangThe.Entity = value;
					if ((value != null))
					{
						value.QuetXes.Add(this);
						this._IDThe = value.MaThe;
					}
					else
					{
						this._IDThe = default(string);
					}
					this.SendPropertyChanged("BangThe");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
