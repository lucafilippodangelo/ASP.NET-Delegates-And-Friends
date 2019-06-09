using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndFriendsTest.GenericsSupportClasses
{
    #region car

    /// <summary>
    /// The reason to create this interface is because allow all the classes implementing this 
    /// interface to be passes as a parm
    /// </summary>
    public interface ICar {}

    /// <summary>
    ///  defining a class "Car" that can accept any "RubberTyre"/"SpecialTyre" and "Chassy"/"SpecialChassy"
    /// </summary>
    /// <typeparam name="ITyre"></typeparam>
    /// <typeparam name="IChassy"></typeparam>
    public class Car<ITyre, IChassy>: ICar where ITyre : RubberTyre where IChassy : Chassy
    {
        public string ACarAttribute { get; set; }
        public ITyre aTyre { get; set; }
        public IChassy aChassy { get; set; }
    }

    #endregion

    #region tyre

    public interface ITyre { }

    /// <summary>
    /// implementing "IRubberType". I can refer to this class by generics
    /// </summary>
    public class RubberTyre : ITyre
    {
        public string Model { get; set; }
    }

    /// <summary>
    /// this class is getting properties of "RubberTyre" and automatically implementing "IRubberType". I can refer to this class by generics
    /// </summary>
    public class SpecialTyre : RubberTyre
    {
        public string MaterialComposition { get; set; }
    }

    #endregion

    #region chassy

    public interface IChassy { }

    /// <summary>
    /// implementing "IRubberType". I can refer to this class by generics
    /// </summary>
    public class Chassy : IChassy
    {
        public string Model { get; set; }
    }

    /// <summary>
    /// this class is getting properties of "RubberTyre" and automatically implementing "IRubberType". I can refer to this class by generics
    /// </summary>
    public class SpecialChassy : Chassy 
    {
        public string MaterialComposition { get; set; }
    }

    #endregion

}// Close Namespace