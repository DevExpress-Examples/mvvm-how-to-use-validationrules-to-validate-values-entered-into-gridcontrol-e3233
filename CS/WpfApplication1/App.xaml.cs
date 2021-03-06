﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Dynamic;
using System.ComponentModel;

namespace WpfApplication1 {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        protected override void OnActivated(EventArgs e) {
            base.OnActivated(e);
            // Creating a dynamic dictionary.
            //dynamic person = new DynamicDictionary();

            //person.FirstName = "Ellen";
            //person.LastName = "Adams";

            //Console.WriteLine(person.firstname + " " + person.lastname);

            //Console.WriteLine(
            //    "Number of dynamic properties:" + person.Count);

            //foreach(var item in person.GetDynamicMemberNames()) {

            //}

        }
    }
    // The class derived from DynamicObject.
    public class DynamicDictionary : DynamicObject {
        // The inner dictionary.
        Dictionary<string, object> dictionary
            = new Dictionary<string, object>();

        // This property returns the number of elements
        // in the inner dictionary.
        public int Count {
            get {
                return dictionary.Count;
            }
        }

        // If you try to get a value of a property 
        // not defined in the class, this method is called.
        public override bool TryGetMember(
            GetMemberBinder binder, out object result) {
            // Converting the property name to lowercase
            // so that property names become case-insensitive.
            string name = binder.Name.ToLower();

            // If the property name is found in a dictionary,
            // set the result parameter to the property value and return true.
            // Otherwise, return false.
            return dictionary.TryGetValue(name, out result);
        }

        // If you try to set a value of a property that is
        // not defined in the class, this method is called.
        public override bool TrySetMember(
            SetMemberBinder binder, object value) {
            // Converting the property name to lowercase
            // so that property names become case-insensitive.
            dictionary[binder.Name.ToLower()] = value;

            // You can always add a value to a dictionary,
            // so this method always returns true.
            return true;
        }
    }

    //class Program {
    //    static void Main(string[] args) {

    //        // The following statement throws an exception at run time.
    //        // There is no "address" property,
    //        // so the TryGetMember method returns false and this causes a
    //        // RuntimeBinderException.
    //        // Console.WriteLine(person.address);
    //    }
    //}


}
