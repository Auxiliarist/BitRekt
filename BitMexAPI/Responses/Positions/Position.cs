using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace BitMexAPI.Responses.Positions
{
    [DebuggerDisplay("Postion: {Symbol}, {Currency}. {LastPrice}, {CurrentQty}")]
    public class Position : INotifyPropertyChanged
    {
        private long? _unrealisedPnl;
        private bool? _isOpen;
        private long? _currentQty;
        private double? _avgEntryPrice;
        private double? _markPrice;
        private double? _liquidationPrice;
        private long? _realisedPnl;
        private long? _posMargin;

        public long Account { get; set; }
        public string Symbol { get; set; }
        public string Currency { get; set; }

        public string Underlying { get; set; }
        public string QuoteCurrency { get; set; }

        public double? Commission { get; set; }

        public double? InitMarginReq { get; set; }
        public double? MaintMarginReq { get; set; }

        public long? RiskLimit { get; set; }
        public double? Leverage { get; set; }
        public bool? CrossMargin { get; set; }
        public double? DeleveragePercentile { get; set; }

        public long? RebalancedPnl { get; set; }
        public long? PrevRealisedPnl { get; set; }
        public long? PrevUnrealisedPnl { get; set; }
        public double? PrevClosePrice { get; set; }

        public DateTime? OpeningTimestamp { get; set; }
        public long? OpeningQty { get; set; }
        public long? OpeningCost { get; set; }
        public long? OpeningComm { get; set; }
        public long? OpenOrderBuyQty { get; set; }
        public long? OpenOrderBuyCost { get; set; }
        public long? OpenOrderBuyPremium { get; set; }
        public long? OpenOrderSellQty { get; set; }
        public long? OpenOrderSellCost { get; set; }
        public long? OpenOrderSellPremium { get; set; }

        public long? ExecBuyQty { get; set; }
        public long? ExecBuyCost { get; set; }
        public long? ExecSellQty { get; set; }
        public long? ExecSellCost { get; set; }
        public long? ExecQty { get; set; }
        public long? ExecCost { get; set; }
        public long? ExecComm { get; set; }

        public DateTime? CurrentTimestamp { get; set; }
        public long? CurrentQty { get => _currentQty; set { _currentQty = value; if (value != null) OnPropertyChanged("CurrentQty"); } }
        public long? CurrentCost { get; set; }
        public long? CurrentComm { get; set; }

        public long? RealisedCost { get; set; }
        public long? UnrealisedCost { get; set; }

        public long? GrossOpenCost { get; set; }
        public long? GrossOpenPremium { get; set; }
        public long? GrossExecCost { get; set; }

        public bool? IsOpen { get => _isOpen; set { if (value != null) _isOpen = value; if (value != null) OnPropertyChanged("IsOpen"); } }
        public double? MarkPrice { get => _markPrice; set { _markPrice = value; if (value != null) OnPropertyChanged("MarkPrice"); } }
        public long? MarkValue { get; set; }
        public long? RiskValue { get; set; }
        public double? HomeNotional { get; set; }
        public double? ForeignNotional { get; set; }

        public string PosState { get; set; }
        public long? PosCost { get; set; }
        public long? PosCost2 { get; set; }
        public long? PosCross { get; set; }
        public long? PosInit { get; set; }
        public long? PosComm { get; set; }
        public long? PosLoss { get; set; }
        public long? PosMargin { get => _posMargin; set { _posMargin = value; if (value != null) OnPropertyChanged("PosMargin"); } }
        public long? PosMaint { get; set; }
        public long? PosAllowance { get; set; }

        public long? TaxableMargin { get; set; }
        public long? InitMargin { get; set; }
        public long? MaintMargin { get; set; }
        public long? SessionMargin { get; set; }
        public long? TargetExcessMargin { get; set; }
        public long? VarMargin { get; set; }
        public long? RealisedGrossPnl { get; set; }
        public long? RealisedTax { get; set; }
        public long? RealisedPnl { get => _realisedPnl; set { _realisedPnl = value; if (value != null) OnPropertyChanged("RealisedPnl"); } }

        public long? UnrealisedGrossPnl { get; set; }
        public long? LongBankrupt { get; set; }
        public long? ShortBankrupt { get; set; }

        public long? TaxBase { get; set; }
        public double? IndicativeTaxRate { get; set; }
        public long? IndicativeTax { get; set; }
        public long? UnrealisedTax { get; set; }
        public long? UnrealisedPnl { get => _unrealisedPnl; set { _unrealisedPnl = value; if (value != null) OnPropertyChanged("UnrealisedPnl"); } }

        public double? UnrealisedPnlPcnt { get; set; }
        public double? UnrealisedRoePcnt { get; set; }
        public double? SimpleQty { get; set; }
        public double? SimpleCost { get; set; }
        public double? SimpleValue { get; set; }
        public double? SimplePnl { get; set; }
        public double? SimplePnlPcnt { get; set; }
        public double? AvgCostPrice { get; set; }
        public double? AvgEntryPrice { get => _avgEntryPrice; set { _avgEntryPrice = value; if (value != null) OnPropertyChanged("AvgEntryPrice"); } }
        public double? BreakEvenPrice { get; set; }
        public double? MarginCallPrice { get; set; }
        public double? LiquidationPrice { get => _liquidationPrice; set { _liquidationPrice = value; if (value != null) OnPropertyChanged("LiquidationPrice"); } }
        public double? BankruptPrice { get; set; }
        public DateTime? Timestamp { get; set; }
        public double? LastPrice { get; set; }
        public long? LastValue { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class PositionComparer : IEqualityComparer<Position>
    {
        public bool Equals(Position x, Position y)
        {
            if (x.Symbol == y.Symbol)
                return true;

            return false;
        }

        public int GetHashCode(Position obj)
        {
            int hashCode = 41;

            hashCode = hashCode * 59 + obj.Symbol.GetHashCode();

            return hashCode;
        }
    }
}