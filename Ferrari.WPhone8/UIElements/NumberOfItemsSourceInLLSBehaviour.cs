//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Interactivity;
//using Microsoft.Phone.Controls;

//namespace Ferrari.WPhone8.UIElements
//{
//    public class NumberOfItemsSourceInLlsBehaviour : Behavior<LongListSelector>
//    {

//        public static readonly DependencyProperty CustomItemsSourceProperty = DependencyProperty.Register(
//            "CustomItemsSource", typeof(IList<Object>), typeof(NumberOfItemsSourceInLlsBehaviour), new PropertyMetadata(default(IList<Object>)));

//        public IList<Object> CustomItemsSource
//        {
//            get
//            {
//                var collection = (IList<Object>) GetValue(CustomItemsSourceProperty);

//                if (collection == null) return null;

//                var result = collection.Take(3).ToList();

//                AssociatedObject.ItemsSource = result;

//                return result;
//            }
//            set
//            {
//                SetValue(CustomItemsSourceProperty, value);
//            }
//        }

//        //public static readonly DependencyProperty NumberOfItemsSourceInLlsProperty = DependencyProperty.Register(
//        //    "NumberOfItemsSourceInLls", typeof(int), typeof(NumberOfItemsSourceInLlsBehaviour), new PropertyMetadata(default(int)));

//        //public int NumberOfItemsSourceInLls
//        //{
//        //    get
//        //    {
//        //        return (int) GetValue(NumberOfItemsSourceInLlsProperty);
//        //    }
//        //    set
//        //    {
//        //        SetValue(NumberOfItemsSourceInLlsProperty, value);
//        //    }
//        //}

//        protected override void OnAttached()
//        {
//            //AssociatedObject.SelectionChanged += AssociatedObjectOnSelectionChanged;

//            //AssociatedObject.ItemRealized += AssociatedObjectOnPropertyChanged;

//            base.OnAttached();
//        }

//        //private void AssociatedObjectOnItemRealized(object sender,
//        //    ItemRealizationEventArgs itemRealizationEventArgs)
//        //{
//        //    if (AssociatedObject.ItemsSource != null)
//        //    {
//        //        AssociatedObject.ItemsSource = new List<Object>
//        //        {
//        //            AssociatedObject.ItemsSource[0],
//        //            AssociatedObject.ItemsSource[1],
//        //            AssociatedObject.ItemsSource[3]
//        //        };
//        //    }
//        //}

//        protected override void OnDetaching()
//        {
//            //AssociatedObject.PropertyChanged -= AssociatedObjectOnPropertyChanged;

//            base.OnDetaching();
//        }

//        //private void AssociatedObjectOnPropertyChanged(object sender,
//        //    PropertyChangedEventArgs propertyChangedEventArgs)
//        //{
//        //    propertyChangedEventArgs.
//        //}
//    }
//}
