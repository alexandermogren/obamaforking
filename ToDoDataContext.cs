using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;


namespace RCmechanics.Model
{

    public class ToDoDataContext : DataContext
    {
        // Pass the connection string to the base class.
        public ToDoDataContext(string connectionString)
            : base(connectionString)
        { }

        // Specify a table for the to-do items.
        public Table<ToDoItem> Items;
        //public Table<ToDoFavCategory> Categories;
    }

    [Table]
    public class ToDoItem : INotifyPropertyChanged, INotifyPropertyChanging
    {

        // Define ID: private field, public property, and database column.
        private int _toDoItemId;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int ToDoItemId
        {
            get { return _toDoItemId; }
            set
            {
                if (_toDoItemId != value)
                {
                    NotifyPropertyChanging("ToDoItemId");
                    _toDoItemId = value;
                    NotifyPropertyChanged("ToDoItemId");
                    
                    NotifyPropertyChanging("Test");
                    _test = value;
                    NotifyPropertyChanged("Test");
                }
            }
        }
        
        // Define item name: private field, public property, and database column.
        private string _itemSpring;

        [Column]
        public string ItemSpring
        {
            get { return _itemSpring; }
            set
            {
                if (_itemSpring != value)
                {
                    NotifyPropertyChanging("ItemSpring");
                    _itemSpring = value;
                    NotifyPropertyChanged("ItemSpring");
                }
            }
        }

        private string _itemCaster;

        [Column]
        public string ItemCaster
        {
            get { return _itemCaster; }
            set
            {
                if (_itemCaster != value)
                {
                    NotifyPropertyChanging("ItemCaster");
                    _itemCaster = value;
                    NotifyPropertyChanged("ItemCaster");
                }
            }
        }

        private string _itemReactiveCaster;

        [Column]
        public string ItemReactiveCaster
        {
            get { return _itemReactiveCaster; }
            set
            {
                if (_itemReactiveCaster != value)
                {
                    NotifyPropertyChanging("ItemReactiveCaster");
                    _itemReactiveCaster = value;
                    NotifyPropertyChanged("ItemReactiveCaster");
                }
            }
        }

        private string _itemCamber;

        [Column]
        public string ItemCamber
        {
            get { return _itemCamber; }
            set
            {
                if (_itemCamber != value)
                {
                    NotifyPropertyChanging("ItemCamber");
                    _itemCamber = value;
                    NotifyPropertyChanged("ItemCamber");
                }
            }
        }

        private string _itemRideHeight;

        [Column]
        public string ItemRideHeight
        {
            get { return _itemRideHeight; }
            set
            {
                if (_itemRideHeight != value)
                {
                    NotifyPropertyChanging("ItemRideHeight");
                    _itemRideHeight = value;
                    NotifyPropertyChanged("ItemRideHeight");
                }
            }
        }

        private string _itemBumpsteer;

        [Column]
        public string ItemBumpsteer
        {
            get { return _itemBumpsteer; }
            set
            {
                if (_itemBumpsteer != value)
                {
                    NotifyPropertyChanging("ItemBumpsteer");
                    _itemBumpsteer = value;
                    NotifyPropertyChanged("ItemBumpsteer");
                }
            }
        }

        private string _itemFrontBall;

        [Column]
        public string ItemFrontBall
        {
            get { return _itemFrontBall; }
            set
            {
                if (_itemFrontBall != value)
                {
                    NotifyPropertyChanging("ItemFrontBall");
                    _itemFrontBall = value;
                    NotifyPropertyChanged("ItemFrontBall");
                }
            }
        }

        private string _itemRearBall;

        [Column]
        public string ItemRearBall
        {
            get { return _itemRearBall; }
            set
            {
                if (_itemRearBall != value)
                {
                    NotifyPropertyChanging("ItemReartBall");
                    _itemRearBall = value;
                    NotifyPropertyChanged("ItemRearBall");
                }
            }
        }
        private string _itemDroop;

        [Column]
        public string ItemDroop
        {
            get { return _itemDroop; }
            set
            {
                if (_itemDroop != value)
                {
                    NotifyPropertyChanging("ItemDroop");
                    _itemDroop = value;
                    NotifyPropertyChanged("ItemDroop");
                }
            }
        }

        private string _itemToeInOut;

        [Column]
        public string ItemToeInOut
        {
            get { return _itemToeInOut; }
            set
            {
                if (_itemToeInOut != value)
                {
                    NotifyPropertyChanging("ItemToeInOut");
                    _itemToeInOut = value;
                    NotifyPropertyChanged("ItemToeInOut");
                }
            }
        }
        private string _itemCarWidth;

        [Column]
        public string ItemCarWidth
        {
            get { return _itemCarWidth; }
            set
            {
                if (_itemCarWidth != value)
                {
                    NotifyPropertyChanging("ItemCarWidth");
                    _itemCarWidth = value;
                    NotifyPropertyChanged("ItemCarWidth");
                }
            }
        }

        private string _itemKingPinGrease;

        [Column]
        public string ItemKingPinGrease
        {
            get { return _itemKingPinGrease; }
            set
            {
                if (_itemKingPinGrease != value)
                {
                    NotifyPropertyChanging("ItemKingPinGrease");
                    _itemKingPinGrease = value;
                    NotifyPropertyChanged("ItemKingPinGrease");
                }
            }
        }

        private string _itemExtra;

        [Column]
        public string ItemExtra
        {
            get { return _itemExtra; }
            set
            {
                if (_itemExtra != value)
                {
                    NotifyPropertyChanging("ItemExtra");
                    _itemExtra = value;
                    NotifyPropertyChanged("ItemExtra");
                }
            }
        }



        private string _itemDriver;

        [Column]
        public string ItemDriver
        {
            get { return _itemDriver; }
            set
            {
                if (_itemDriver != value)
                {
                    NotifyPropertyChanging("ItemDriver");
                    _itemDriver = value;
                    NotifyPropertyChanged("ItemDriver");
                }
            }
        }

        private string _itemCity;

        [Column]
        public string ItemCity
        {
            get { return _itemCity; }
            set
            {
                if (_itemCity != value)
                {
                    NotifyPropertyChanging("ItemCity");
                    _itemCity = value;
                    NotifyPropertyChanged("ItemCity");
                }
            }
        }

        private string _itemCountry;

        [Column]
        public string ItemCountry
        {
            get { return _itemCountry; }
            set
            {
                if (_itemCountry != value)
                {
                    NotifyPropertyChanging("ItemCountry");
                    _itemCountry = value;
                    NotifyPropertyChanged("ItemCountry");
                }
            }
        }

        private string _itemEvent;

        [Column]
        public string ItemEvent
        {
            get { return _itemEvent; }
            set
            {
                if (_itemEvent != value)
                {
                    NotifyPropertyChanging("ItemEvent");
                    _itemEvent = value;
                    NotifyPropertyChanged("ItemEvent");
                }
            }
        }

        private string _itemEventDate;

        [Column]
        public string ItemEventDate
        {
            get { return _itemEventDate; }
            set
            {
                if (_itemEventDate != value)
                {
                    NotifyPropertyChanging("ItemEventDate");
                    _itemEventDate = value;
                    NotifyPropertyChanged("ItemEventDate");
                }
            }
        }
        
        private string _favorite;

        [Column]
        public string Favorite
        {
            get { return _favorite; }
            set
            {
                if (_favorite != value)
                {
                    NotifyPropertyChanging("Favorite");
                    _favorite = value;
                    NotifyPropertyChanged("Favorite");
                }
            }
        }

        private int _test;

        [Column]
        public int Test
        {
            get { return _test; }
            set
            {
                if (_test != value)
                {
                    NotifyPropertyChanging("Test");
                    //_test = value;
                    NotifyPropertyChanged("Test");
                }
            }
        }

        private string _itembrandComp;

        [Column]
        public string ItemBrandComp
        {
            get { return _itembrandComp; }
            set
            {
                if (_itembrandComp != value)
                {
                    NotifyPropertyChanging("ItemBrandComp");
                    _itembrandComp = value;
                    NotifyPropertyChanged("ItemBrandComp");
                }
            }
        }

        private string _itembrandCompRear;

        [Column]
        public string ItemBrandCompRear
        {
            get { return _itembrandCompRear; }
            set
            {
                if (_itembrandCompRear != value)
                {
                    NotifyPropertyChanging("ItemBrandCompRear");
                    _itembrandCompRear = value;
                    NotifyPropertyChanged("ItemBrandCompRear");
                }
            }
        }

        private string _itemDiaFront;

        [Column]
        public string ItemDiaFront
        {
            get { return _itemDiaFront; }
            set
            {
                if (_itemDiaFront != value)
                {
                    NotifyPropertyChanging("ItemDiaFront");
                    _itemDiaFront = value;
                    NotifyPropertyChanged("ItemDiaFront");
                }
            }
        }
        
        private string _itemDiaRear;

        [Column]
        public string ItemDiaRear
        {
            get { return _itemDiaRear; }
            set
            {
                if (_itemDiaRear != value)
                {
                    NotifyPropertyChanging("ItemDiaRear");
                    _itemDiaRear = value;
                    NotifyPropertyChanged("ItemDiaRear");
                }
            }
        }

        private string _itemtireTimeFront;

        [Column]
        public string ItemtireTimeFront
        {
            get { return _itemtireTimeFront; }
            set
            {
                if (_itemtireTimeFront != value)
                {
                    NotifyPropertyChanging("ItemtireTimeFront");
                    _itemtireTimeFront = value;
                    NotifyPropertyChanged("ItemtireTimeFront");
                }
            }
        }

        private string _itemtireTimeRear;

        [Column]
        public string ItemtireTimeRear
        {
            get { return _itemtireTimeRear; }
            set
            {
                if (_itemtireTimeRear != value)
                {
                    NotifyPropertyChanging("ItemtireTimeRear");
                    _itemtireTimeRear = value;
                    NotifyPropertyChanged("ItemtireTimeRear");
                }
            }
        }

        private string _itemproducbrandFront;

        [Column]
        public string ItemproducbrandFront
        {
            get { return _itemproducbrandFront; }
            set
            {
                if (_itemproducbrandFront != value)
                {
                    NotifyPropertyChanging("ItemproducbrandFront");
                    _itemproducbrandFront = value;
                    NotifyPropertyChanged("ItemproducbrandFront");
                }
            }
        }

        private string _itemproducbrandRear;

        [Column]
        public string ItemproducbrandRear
        {
            get { return _itemproducbrandRear; }
            set
            {
                if (_itemproducbrandRear != value)
                {
                    NotifyPropertyChanging("ItemproducbrandRear");
                    _itemproducbrandRear = value;
                    NotifyPropertyChanged("ItemproducbrandRear");
                }
            }
        }

        private string _itemshockOil;

        [Column]
        public string ItemshockOil
        {
            get { return _itemshockOil; }
            set
            {
                if (_itemshockOil != value)
                {
                    NotifyPropertyChanging("ItemshockOil");
                    _itemshockOil = value;
                    NotifyPropertyChanged("ItemshockOil");
                }
            }
        }

        private string _itemdamperGrease;

        [Column]
        public string ItemdamperGrease
        {
            get { return _itemdamperGrease; }
            set
            {
                if (_itemdamperGrease != value)
                {
                    NotifyPropertyChanging("ItemdamperGrease");
                    _itemdamperGrease = value;
                    NotifyPropertyChanged("ItemdamperGrease");
                }
            }
        }

        private string _itemcarWidthR;

        [Column]
        public string ItemcarWidthR
        {
            get { return _itemcarWidthR; }
            set
            {
                if (_itemcarWidthR != value)
                {
                    NotifyPropertyChanging("ItemcarWidthR");
                    _itemcarWidthR = value;
                    NotifyPropertyChanged("ItemcarWidthR");
                }
            }
        }

        private string _itemShockSpring;

        [Column]
        public string ItemShockSpring
        {
            get { return _itemShockSpring; }
            set
            {
                if (_itemShockSpring != value)
                {
                    NotifyPropertyChanging("ItemShockSpring");
                    _itemShockSpring = value;
                    NotifyPropertyChanged("ItemShockSpring");
                }
            }
        }

        private string _itemrideheightrear;

        [Column]
        public string Itemrideheightrear
        {
            get { return _itemrideheightrear; }
            set
            {
                if (_itemrideheightrear != value)
                {
                    NotifyPropertyChanging("Itemrideheightrear");
                    _itemrideheightrear = value;
                    NotifyPropertyChanged("Itemrideheightrear");
                }
            }
        }

        private string _itemsod;

        [Column]
        public string Itemsod
        {
            get { return _itemsod; }
            set
            {
                if (_itemsod != value)
                {
                    NotifyPropertyChanging("Itemsod");
                    _itemsod = value;
                    NotifyPropertyChanged("Itemsod");
                }
            }
        }

        private string _itemRearDrop;

        [Column]
        public string ItemRearDrop
        {
            get { return _itemRearDrop; }
            set
            {
                if (_itemRearDrop != value)
                {
                    NotifyPropertyChanging("ItemRearDrop");
                    _itemRearDrop = value;
                    NotifyPropertyChanged("ItemRearDrop");
                }
            }
        }

        private string _itemESC;

        [Column]
        public string ItemESC
        {
            get { return _itemESC; }
            set
            {
                if (_itemESC != value)
                {
                    NotifyPropertyChanging("ItemESC");
                    _itemESC = value;
                    NotifyPropertyChanged("ItemESC");
                }
            }
        }

        private string _itemESCfw;

        [Column]
        public string ItemESCfw
        {
            get { return _itemESCfw; }
            set
            {
                if (_itemESCfw != value)
                {
                    NotifyPropertyChanging("ItemESCfw");
                    _itemESCfw = value;
                    NotifyPropertyChanged("ItemESCfw");
                }
            }
        }

        private string _itemESCsetup;

        [Column]
        public string ItemESCsetup
        {
            get { return _itemESCsetup; }
            set
            {
                if (_itemESCsetup != value)
                {
                    NotifyPropertyChanging("ItemESCsetup");
                    _itemESCsetup = value;
                    NotifyPropertyChanged("ItemESCsetup");
                }
            }
        }

        private string _itemMotor;

        [Column]
        public string ItemMotor
        {
            get { return _itemMotor; }
            set
            {
                if (_itemMotor != value)
                {
                    NotifyPropertyChanging("ItemMotor");
                    _itemMotor = value;
                    NotifyPropertyChanged("ItemMotor");
                }
            }
        }

        private string _itemRollout;

        [Column]
        public string ItemRollout
        {
            get { return _itemRollout; }
            set
            {
                if (_itemRollout != value)
                {
                    NotifyPropertyChanging("ItemRollout");
                    _itemRollout = value;
                    NotifyPropertyChanged("ItemRollout");
                }
            }
        }

        private string _itemReceiver;

        [Column]
        public string ItemReceiver
        {
            get { return _itemReceiver; }
            set
            {
                if (_itemReceiver != value)
                {
                    NotifyPropertyChanging("ItemReceiver");
                    _itemReceiver = value;
                    NotifyPropertyChanged("ItemReceiver");
                }
            }
        }

        private string _itemServo;

        [Column]
        public string ItemServo
        {
            get { return _itemServo; }
            set
            {
                if (_itemServo != value)
                {
                    NotifyPropertyChanging("ItemServo");
                    _itemServo = value;
                    NotifyPropertyChanged("ItemServo");
                }
            }
        }

        private string _itemBattery;

        [Column]
        public string ItemBattery
        {
            get { return _itemBattery; }
            set
            {
                if (_itemBattery != value)
                {
                    NotifyPropertyChanging("ItemBattery");
                    _itemBattery = value;
                    NotifyPropertyChanged("ItemBattery");
                }
            }
        }

        private string _itemTCsurface;

        [Column]
        public string ItemTCsurface
        {
            get { return _itemTCsurface; }
            set
            {
                if (_itemTCsurface != value)
                {
                    NotifyPropertyChanging("ItemTCsurface");
                    _itemTCsurface = value;
                    NotifyPropertyChanged("ItemTCsurface");
                }
            }
        }

        private string _itemTCtraction;

        [Column]
        public string ItemTCtraction
        {
            get { return _itemTCtraction; }
            set
            {
                if (_itemTCtraction != value)
                {
                    NotifyPropertyChanging("ItemTCtraction");
                    _itemTCtraction = value;
                    NotifyPropertyChanged("ItemTCtraction");
                }
            }
        }

        private string _itemTCcomposition;

        [Column]
        public string ItemTCcomposition
        {
            get { return _itemTCcomposition; }
            set
            {
                if (_itemTCcomposition != value)
                {
                    NotifyPropertyChanging("ItemTCcomposition");
                    _itemTCcomposition = value;
                    NotifyPropertyChanged("ItemTCcomposition");
                }
            }
        }

        private string _itemQualifying;

        [Column]
        public string ItemQualifying
        {
            get { return _itemQualifying; }
            set
            {
                if (_itemQualifying != value)
                {
                    NotifyPropertyChanging("ItemQualifying");
                    _itemQualifying = value;
                    NotifyPropertyChanged("ItemQualifying");
                }
            }
        }

        private string _itemFinish;

        [Column]
        public string ItemFinish
        {
            get { return _itemFinish; }
            set
            {
                if (_itemFinish != value)
                {
                    NotifyPropertyChanging("ItemFinish");
                    _itemFinish = value;
                    NotifyPropertyChanged("ItemFinish");
                }
            }
        }

        private string _itemRCchassi;

        [Column]
        public string ItemRCchassi
        {
            get { return _itemRCchassi; }
            set
            {
                if (_itemRCchassi != value)
                {
                    NotifyPropertyChanging("ItemRCchassi");
                    _itemRCchassi = value;
                    NotifyPropertyChanged("ItemRCchassi");
                }
            }
        }

        private string _itemRCweight;

        [Column]
        public string ItemRCweight
        {
            get { return _itemRCweight; }
            set
            {
                if (_itemRCweight != value)
                {
                    NotifyPropertyChanging("ItemRCweight");
                    _itemRCweight = value;
                    NotifyPropertyChanged("ItemRCweight");
                }
            }
        }

        private string _itemRCbody;

        [Column]
        public string ItemRCbody
        {
            get { return _itemRCbody; }
            set
            {
                if (_itemRCbody != value)
                {
                    NotifyPropertyChanging("ItemRCbody");
                    _itemRCbody = value;
                    NotifyPropertyChanged("ItemRCbody");
                }
            }
        }

        private string _itemcomments;

        [Column]
        public string Itemcomments
        {
            get { return _itemcomments; }
            set
            {
                if (_itemcomments != value)
                {
                    NotifyPropertyChanging("Itemcomments");
                    _itemcomments = value;
                    NotifyPropertyChanged("Itemcomments");
                }
            }
        }
        #region junk
        // Define completion value: private field, public property, and database column.
        private bool _isComplete;

        [Column]
        public bool IsComplete
        {
            get { return _isComplete; }
            set
            {
                if (_isComplete != value)
                {
                    NotifyPropertyChanging("IsComplete");
                    _isComplete = value;
                    NotifyPropertyChanged("IsComplete");
                }
            }
        }
        
        // Version column aids update performance.
        [Column(IsVersion = true)]
        private Binary _version;
        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify that a property changed
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;
        

        // Used to notify that a property is about to change
        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        #endregion
    }

}