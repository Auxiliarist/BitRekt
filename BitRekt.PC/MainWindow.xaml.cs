using BitRekt.ViewModels;
using MahApps.Metro.Controls;
using System.Collections.Generic;
using ReactiveUI;
using System.Windows;
using System.Reactive.Disposables;
using System;
using System.Reactive.Linq;

namespace BitRekt.PC
{
    /// <summary> Interaction logic for MainWindow.xaml </summary>
    public partial class MainWindow : MetroWindow, IViewFor<MainViewModel>
    {
        CompositeDisposable CompositeDisposable = new CompositeDisposable();

        public MainWindow()
        {
            InitializeComponent();

            //DataContext = new MainViewModel();

            ViewModel = new MainViewModel();

            // Setup the bindings
            // Note: We have to use WhenActivated here, since we need to dispose the
            // bindings on XAML-based platforms, or else the bindings leak memory.
            this.WhenActivated(d =>
            {
                d(this.OneWayBind(ViewModel, vm => vm.Instruments, v => v.comboBox.ItemsSource));
                d(this.Bind(ViewModel, vm => vm.ActiveInstrument, v => v.comboBox.SelectedItem));
                //d(this.OneWayBind(ViewModel, vm => vm.ActiveInstrument.Symbol, v => v.label12.Content));

                d(this.OneWayBind(ViewModel, vm => vm.Positions, v => v.dataGrid.ItemsSource));

                d(this.OneWayBind(ViewModel, vm => vm.WalletString, v => v.label10.Content));
                d(this.OneWayBind(ViewModel, vm => vm.DateString, v => v.label11.Content));

                d(this.BindCommand(ViewModel, vm => vm.TakeProfitCommand, v => v.button2));
            });
        }

        // Dispose
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }

        public MainViewModel ViewModel { get => (MainViewModel)GetValue(ViewModelProperty); set => SetValue(ViewModelProperty, value); }
        object IViewFor.ViewModel { get => ViewModel; set => ViewModel = (MainViewModel)value; }

        public static readonly DependencyProperty ViewModelProperty =
        DependencyProperty.Register("ViewModel", typeof(MainViewModel), typeof(MainWindow));
    }
}