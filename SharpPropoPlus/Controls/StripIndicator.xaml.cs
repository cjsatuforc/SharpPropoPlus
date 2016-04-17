﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SharpPropoPlus.Controls
{
  /// <summary>
  /// Interaction logic for StripIndicator.xaml
  /// </summary>
  public partial class StripIndicator : UserControl
  {

    //[DllImport("uxtheme.dll", EntryPoint = "#95")]
    //public static extern uint GetImmersiveColorFromColorSetEx(uint dwImmersiveColorSet, uint dwImmersiveColorType, bool bIgnoreHighContrast, uint dwHighContrastCacheMode);
    //[DllImport("uxtheme.dll", EntryPoint = "#96")]
    //public static extern uint GetImmersiveColorTypeFromName(IntPtr pName);
    //[DllImport("uxtheme.dll", EntryPoint = "#98")]
    //public static extern int GetImmersiveUserColorSetPreference(bool bForceCheckRegistry, bool bSkipCheckOnFail);

    public StripIndicator()
    {
      InitializeComponent();

      Loaded += new RoutedEventHandler(MyProgressBar_Loaded);

    }

    void MyProgressBar_Loaded(object sender, RoutedEventArgs e)
    {
      Update();
    }

    private static readonly DependencyProperty MaximumProperty = DependencyProperty.Register("Maximum", typeof(double), typeof(StripIndicator), new PropertyMetadata(100d, OnMaximumChanged));
    public double Maximum
    {
      get { return (double)GetValue(MaximumProperty); }
      set { SetValue(MaximumProperty, value); }
    }


    private static readonly DependencyProperty MinimumProperty = DependencyProperty.Register("Minimum", typeof(double), typeof(StripIndicator), new PropertyMetadata(0d, OnMinimumChanged));
    public double Minimum
    {
      get { return (double)GetValue(MinimumProperty); }
      set { SetValue(MinimumProperty, value); }
    }

    private static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(double), typeof(StripIndicator), new PropertyMetadata(50d, OnValueChanged));
    public double Value
    {
      get { return (double)GetValue(ValueProperty); }
      set { SetValue(ValueProperty, value); }
    }

    private static readonly DependencyProperty ProgressBarWidthProperty = DependencyProperty.Register("ProgressBarWidth", typeof(double), typeof(StripIndicator), null);
    private double ProgressBarWidth
    {
      get { return (double)GetValue(ProgressBarWidthProperty); }
      set { SetValue(ProgressBarWidthProperty, value); }
    }

    private new static readonly DependencyProperty BorderThicknessProperty = DependencyProperty.Register("BorderThickness", typeof(Thickness), typeof(StripIndicator), null);
    public new Thickness BorderThickness
    {
      get { return (Thickness)GetValue(BorderThicknessProperty); }
      set { SetValue(BorderThicknessProperty, value); }
    }

    private new static readonly DependencyProperty BorderBrushProperty = DependencyProperty.Register("BorderBrush", typeof(Brush), typeof(StripIndicator), null);
    public new Brush BorderBrush
    {
      get { return (Brush)GetValue(BorderBrushProperty); }
      set { SetValue(BorderBrushProperty, value); }
    }

    private static readonly DependencyProperty FillProperty = DependencyProperty.Register("Fill", typeof(Brush), typeof(StripIndicator), null);
    public Brush Fill
    {
      get { return (Brush)GetValue(FillProperty); }
      set { SetValue(FillProperty, value); }
    }

    static void OnValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
    {
      var stripIndicator = o as StripIndicator;
      stripIndicator?.Update();
    }

    static void OnMinimumChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
    {
      var stripIndicator = o as StripIndicator;
      stripIndicator?.Update();
    }

    static void OnMaximumChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
    {
      var stripIndicator = o as StripIndicator;
      stripIndicator?.Update();
    }


    protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
    {
      base.OnRenderSizeChanged(sizeInfo);
      Update();
    }

    void Update()
    {
      // The -2 is for the borders - there are probably better ways of doing this since you
      // may want your template to have variable bits like border width etc which you'd use
      // TemplateBinding for

      //uint colour1 = GetImmersiveColorFromColorSetEx((uint)GetImmersiveUserColorSetPreference(false, false), GetImmersiveColorTypeFromName(Marshal.StringToHGlobalUni("ImmersiveStartSelectionBackground")), false, 0);
      //Color colour = Color.FromArgb((byte)((0xFF000000 & colour1) >> 24), (byte)(0x000000FF & colour1),
      //    (byte)((0x0000FF00 & colour1) >> 8), (byte)((0x00FF0000 & colour1) >> 16));

      //BorderBrush = new SolidColorBrush(colour);
      //Fill = new SolidColorBrush(colour);

      ProgressBarWidth = Math.Min((Value / (Maximum + Minimum) * ActualWidth) - (BorderThickness.Left + BorderThickness.Right), ActualWidth - (BorderThickness.Left + BorderThickness.Right));
    }
  }
}