

















// Generated on 01/12/2017 03:53:15
using System;
using System.Collections.Generic;
using ShadowEmu.Common.GameData.D2O;

namespace ShadowEmu.Common.Protocol.Data
{

[D2oClass("SubAreas")]
    
public class SubArea : IDataObject
{

public const String MODULE = "SubAreas";
        public int id;
        public uint nameId;
        public int areaId;
        public List<AmbientSound> ambientSounds;
        public List<List<int>> playlists;
        public List<double> mapIds;
        public Rectangle bounds;
        public List<int> shape;
        public List<uint> customWorldMap;
        public int packId;
        public uint level;
        public Boolean isConquestVillage;
        public Boolean basicAccountAllowed;
        public Boolean displayOnWorldMap;
        public Boolean mountAutoTripAllowed;

        public List<uint> monsters;
        public List<double> entranceMapIds;
        public List<double> exitMapIds;
        public Boolean capturable;
        public List<uint> achievements;
        public List<List<double>> quests;
        public List<List<double>> npcs;
        public int exploreAchievementId;
        public Boolean isDiscovered;
        public List<int> harvestables;
     //   public var id:int;
      
      //public var nameId:uint;
      
      //public var areaId:int;
      
      //public var ambientSounds:Vector.<AmbientSound>;
      
      //public var playlists:Vector.<Vector.<int>>;
      
      //public var mapIds:Vector.<Number>;
      
      //public var bounds:Rectangle;
      
      //public var shape:Vector.<int>;
      
      //public var customWorldMap:Vector.<uint>;
      
      //public var packId:int;
      
      //public var level:uint;
      
      //public var isConquestVillage:Boolean;
      
      //public var basicAccountAllowed:Boolean;
      
      //public var displayOnWorldMap:Boolean;
      
      //public var mountAutoTripAllowed:Boolean;
      
      //public var monsters:Vector.<uint>;
      
      //public var entranceMapIds:Vector.<Number>;
      
      //public var exitMapIds:Vector.<Number>;
      
      //public var capturable:Boolean;
      
      //public var achievements:Vector.<uint>;
      
      //public var quests:Vector.<Vector.<Number>>;
      
      //public var npcs:Vector.<Vector.<Number>>;
      
      //public var exploreAchievementId:int;
      
      //public var isDiscovered:Boolean;
      
      //public var harvestables:Vector.<int>;

}

}