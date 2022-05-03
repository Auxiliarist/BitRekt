using System;
using System.Runtime.Serialization;

namespace BitMexAPI.Responses.Instruments
{
    [DataContract]
    public class Instrument
    {
        /// <summary> Gets or Sets Symbol </summary>
        [DataMember(Name = "symbol", EmitDefaultValue = false)]
        public string Symbol { get; set; }

        /// <summary> Gets or Sets RootSymbol </summary>
        [DataMember(Name = "rootSymbol", EmitDefaultValue = false)]
        public string RootSymbol { get; set; }

        /// <summary> Gets or Sets State </summary>
        [DataMember(Name = "state", EmitDefaultValue = false)]
        public string State { get; set; }

        /// <summary> Gets or Sets Typ </summary>
        [DataMember(Name = "typ", EmitDefaultValue = false)]
        public string Typ { get; set; }

        /// <summary> Gets or Sets Listing </summary>
        [DataMember(Name = "listing", EmitDefaultValue = false)]
        public DateTime? Listing { get; set; }

        /// <summary> Gets or Sets Front </summary>
        [DataMember(Name = "front", EmitDefaultValue = false)]
        public DateTime? Front { get; set; }

        /// <summary> Gets or Sets Expiry </summary>
        [DataMember(Name = "expiry", EmitDefaultValue = false)]
        public DateTime? Expiry { get; set; }

        /// <summary> Gets or Sets Settle </summary>
        [DataMember(Name = "settle", EmitDefaultValue = false)]
        public DateTime? Settle { get; set; }

        /// <summary> Gets or Sets RelistInterval </summary>
        [DataMember(Name = "relistInterval", EmitDefaultValue = false)]
        public DateTime? RelistInterval { get; set; }

        /// <summary> Gets or Sets InverseLeg </summary>
        [DataMember(Name = "inverseLeg", EmitDefaultValue = false)]
        public string InverseLeg { get; set; }

        /// <summary> Gets or Sets SellLeg </summary>
        [DataMember(Name = "sellLeg", EmitDefaultValue = false)]
        public string SellLeg { get; set; }

        /// <summary> Gets or Sets BuyLeg </summary>
        [DataMember(Name = "buyLeg", EmitDefaultValue = false)]
        public string BuyLeg { get; set; }

        /// <summary> Gets or Sets OptionStrikePcnt </summary>
        [DataMember(Name = "optionStrikePcnt", EmitDefaultValue = false)]
        public double? OptionStrikePcnt { get; set; }

        /// <summary> Gets or Sets OptionStrikeRound </summary>
        [DataMember(Name = "optionStrikeRound", EmitDefaultValue = false)]
        public double? OptionStrikeRound { get; set; }

        /// <summary> Gets or Sets OptionStrikePrice </summary>
        [DataMember(Name = "optionStrikePrice", EmitDefaultValue = false)]
        public double? OptionStrikePrice { get; set; }

        /// <summary> Gets or Sets OptionMultiplier </summary>
        [DataMember(Name = "optionMultiplier", EmitDefaultValue = false)]
        public double? OptionMultiplier { get; set; }

        /// <summary> Gets or Sets PositionCurrency </summary>
        [DataMember(Name = "positionCurrency", EmitDefaultValue = false)]
        public string PositionCurrency { get; set; }

        /// <summary> Gets or Sets Underlying </summary>
        [DataMember(Name = "underlying", EmitDefaultValue = false)]
        public string Underlying { get; set; }

        /// <summary> Gets or Sets QuoteCurrency </summary>
        [DataMember(Name = "quoteCurrency", EmitDefaultValue = false)]
        public string QuoteCurrency { get; set; }

        /// <summary> Gets or Sets UnderlyingSymbol </summary>
        [DataMember(Name = "underlyingSymbol", EmitDefaultValue = false)]
        public string UnderlyingSymbol { get; set; }

        /// <summary> Gets or Sets Reference </summary>
        [DataMember(Name = "reference", EmitDefaultValue = false)]
        public string Reference { get; set; }

        /// <summary> Gets or Sets ReferenceSymbol </summary>
        [DataMember(Name = "referenceSymbol", EmitDefaultValue = false)]
        public string ReferenceSymbol { get; set; }

        /// <summary> Gets or Sets CalcInterval </summary>
        [DataMember(Name = "calcInterval", EmitDefaultValue = false)]
        public DateTime? CalcInterval { get; set; }

        /// <summary> Gets or Sets PublishInterval </summary>
        [DataMember(Name = "publishInterval", EmitDefaultValue = false)]
        public DateTime? PublishInterval { get; set; }

        /// <summary> Gets or Sets PublishTime </summary>
        [DataMember(Name = "publishTime", EmitDefaultValue = false)]
        public DateTime? PublishTime { get; set; }

        /// <summary> Gets or Sets MaxOrderQty </summary>
        [DataMember(Name = "maxOrderQty", EmitDefaultValue = false)]
        public decimal? MaxOrderQty { get; set; }

        /// <summary> Gets or Sets MaxPrice </summary>
        [DataMember(Name = "maxPrice", EmitDefaultValue = false)]
        public double? MaxPrice { get; set; }

        /// <summary> Gets or Sets LotSize </summary>
        [DataMember(Name = "lotSize", EmitDefaultValue = false)]
        public decimal? LotSize { get; set; }

        /// <summary> Gets or Sets TickSize </summary>
        [DataMember(Name = "tickSize", EmitDefaultValue = false)]
        public double? TickSize { get; set; }

        /// <summary> Gets or Sets Multiplier </summary>
        [DataMember(Name = "multiplier", EmitDefaultValue = false)]
        public decimal? Multiplier { get; set; }

        /// <summary> Gets or Sets SettlCurrency </summary>
        [DataMember(Name = "settlCurrency", EmitDefaultValue = false)]
        public string SettlCurrency { get; set; }

        /// <summary> Gets or Sets UnderlyingToPositionMultiplier </summary>
        [DataMember(Name = "underlyingToPositionMultiplier", EmitDefaultValue = false)]
        public decimal? UnderlyingToPositionMultiplier { get; set; }

        /// <summary> Gets or Sets UnderlyingToSettleMultiplier </summary>
        [DataMember(Name = "underlyingToSettleMultiplier", EmitDefaultValue = false)]
        public decimal? UnderlyingToSettleMultiplier { get; set; }

        /// <summary> Gets or Sets QuoteToSettleMultiplier </summary>
        [DataMember(Name = "quoteToSettleMultiplier", EmitDefaultValue = false)]
        public decimal? QuoteToSettleMultiplier { get; set; }

        /// <summary> Gets or Sets IsQuanto </summary>
        [DataMember(Name = "isQuanto", EmitDefaultValue = false)]
        public bool? IsQuanto { get; set; }

        /// <summary> Gets or Sets IsInverse </summary>
        [DataMember(Name = "isInverse", EmitDefaultValue = false)]
        public bool? IsInverse { get; set; }

        /// <summary> Gets or Sets InitMargin </summary>
        [DataMember(Name = "initMargin", EmitDefaultValue = false)]
        public double? InitMargin { get; set; }

        /// <summary> Gets or Sets MaintMargin </summary>
        [DataMember(Name = "maintMargin", EmitDefaultValue = false)]
        public double? MaintMargin { get; set; }

        /// <summary> Gets or Sets RiskLimit </summary>
        [DataMember(Name = "riskLimit", EmitDefaultValue = false)]
        public decimal? RiskLimit { get; set; }

        /// <summary> Gets or Sets RiskStep </summary>
        [DataMember(Name = "riskStep", EmitDefaultValue = false)]
        public decimal? RiskStep { get; set; }

        /// <summary> Gets or Sets Limit </summary>
        [DataMember(Name = "limit", EmitDefaultValue = false)]
        public double? Limit { get; set; }

        /// <summary> Gets or Sets Capped </summary>
        [DataMember(Name = "capped", EmitDefaultValue = false)]
        public bool? Capped { get; set; }

        /// <summary> Gets or Sets Taxed </summary>
        [DataMember(Name = "taxed", EmitDefaultValue = false)]
        public bool? Taxed { get; set; }

        /// <summary> Gets or Sets Deleverage </summary>
        [DataMember(Name = "deleverage", EmitDefaultValue = false)]
        public bool? Deleverage { get; set; }

        /// <summary> Gets or Sets MakerFee </summary>
        [DataMember(Name = "makerFee", EmitDefaultValue = false)]
        public double? MakerFee { get; set; }

        /// <summary> Gets or Sets TakerFee </summary>
        [DataMember(Name = "takerFee", EmitDefaultValue = false)]
        public double? TakerFee { get; set; }

        /// <summary> Gets or Sets SettlementFee </summary>
        [DataMember(Name = "settlementFee", EmitDefaultValue = false)]
        public double? SettlementFee { get; set; }

        /// <summary> Gets or Sets InsuranceFee </summary>
        [DataMember(Name = "insuranceFee", EmitDefaultValue = false)]
        public double? InsuranceFee { get; set; }

        /// <summary> Gets or Sets FundingBaseSymbol </summary>
        [DataMember(Name = "fundingBaseSymbol", EmitDefaultValue = false)]
        public string FundingBaseSymbol { get; set; }

        /// <summary> Gets or Sets FundingQuoteSymbol </summary>
        [DataMember(Name = "fundingQuoteSymbol", EmitDefaultValue = false)]
        public string FundingQuoteSymbol { get; set; }

        /// <summary> Gets or Sets FundingPremiumSymbol </summary>
        [DataMember(Name = "fundingPremiumSymbol", EmitDefaultValue = false)]
        public string FundingPremiumSymbol { get; set; }

        /// <summary> Gets or Sets FundingTimestamp </summary>
        [DataMember(Name = "fundingTimestamp", EmitDefaultValue = false)]
        public DateTime? FundingTimestamp { get; set; }

        /// <summary> Gets or Sets FundingInterval </summary>
        [DataMember(Name = "fundingInterval", EmitDefaultValue = false)]
        public DateTime? FundingInterval { get; set; }

        /// <summary> Gets or Sets FundingRate </summary>
        [DataMember(Name = "fundingRate", EmitDefaultValue = false)]
        public double? FundingRate { get; set; }

        /// <summary> Gets or Sets IndicativeFundingRate </summary>
        [DataMember(Name = "indicativeFundingRate", EmitDefaultValue = false)]
        public double? IndicativeFundingRate { get; set; }

        /// <summary> Gets or Sets RebalanceTimestamp </summary>
        [DataMember(Name = "rebalanceTimestamp", EmitDefaultValue = false)]
        public DateTime? RebalanceTimestamp { get; set; }

        /// <summary> Gets or Sets RebalanceInterval </summary>
        [DataMember(Name = "rebalanceInterval", EmitDefaultValue = false)]
        public DateTime? RebalanceInterval { get; set; }

        /// <summary> Gets or Sets OpeningTimestamp </summary>
        [DataMember(Name = "openingTimestamp", EmitDefaultValue = false)]
        public DateTime? OpeningTimestamp { get; set; }

        /// <summary> Gets or Sets ClosingTimestamp </summary>
        [DataMember(Name = "closingTimestamp", EmitDefaultValue = false)]
        public DateTime? ClosingTimestamp { get; set; }

        /// <summary> Gets or Sets SessionInterval </summary>
        [DataMember(Name = "sessionInterval", EmitDefaultValue = false)]
        public DateTime? SessionInterval { get; set; }

        /// <summary> Gets or Sets PrevClosePrice </summary>
        [DataMember(Name = "prevClosePrice", EmitDefaultValue = false)]
        public double? PrevClosePrice { get; set; }

        /// <summary> Gets or Sets LimitDownPrice </summary>
        [DataMember(Name = "limitDownPrice", EmitDefaultValue = false)]
        public double? LimitDownPrice { get; set; }

        /// <summary> Gets or Sets LimitUpPrice </summary>
        [DataMember(Name = "limitUpPrice", EmitDefaultValue = false)]
        public double? LimitUpPrice { get; set; }

        /// <summary> Gets or Sets BankruptLimitDownPrice </summary>
        [DataMember(Name = "bankruptLimitDownPrice", EmitDefaultValue = false)]
        public double? BankruptLimitDownPrice { get; set; }

        /// <summary> Gets or Sets BankruptLimitUpPrice </summary>
        [DataMember(Name = "bankruptLimitUpPrice", EmitDefaultValue = false)]
        public double? BankruptLimitUpPrice { get; set; }

        /// <summary> Gets or Sets PrevTotalVolume </summary>
        [DataMember(Name = "prevTotalVolume", EmitDefaultValue = false)]
        public decimal? PrevTotalVolume { get; set; }

        /// <summary> Gets or Sets TotalVolume </summary>
        [DataMember(Name = "totalVolume", EmitDefaultValue = false)]
        public decimal? TotalVolume { get; set; }

        /// <summary> Gets or Sets Volume </summary>
        [DataMember(Name = "volume", EmitDefaultValue = false)]
        public decimal? Volume { get; set; }

        /// <summary> Gets or Sets Volume24h </summary>
        [DataMember(Name = "volume24h", EmitDefaultValue = false)]
        public decimal? Volume24h { get; set; }

        /// <summary> Gets or Sets PrevTotalTurnover </summary>
        [DataMember(Name = "prevTotalTurnover", EmitDefaultValue = false)]
        public decimal? PrevTotalTurnover { get; set; }

        /// <summary> Gets or Sets TotalTurnover </summary>
        [DataMember(Name = "totalTurnover", EmitDefaultValue = false)]
        public decimal? TotalTurnover { get; set; }

        /// <summary> Gets or Sets Turnover </summary>
        [DataMember(Name = "turnover", EmitDefaultValue = false)]
        public decimal? Turnover { get; set; }

        /// <summary> Gets or Sets Turnover24h </summary>
        [DataMember(Name = "turnover24h", EmitDefaultValue = false)]
        public decimal? Turnover24h { get; set; }

        /// <summary> Gets or Sets PrevPrice24h </summary>
        [DataMember(Name = "prevPrice24h", EmitDefaultValue = false)]
        public double? PrevPrice24h { get; set; }

        /// <summary> Gets or Sets Vwap </summary>
        [DataMember(Name = "vwap", EmitDefaultValue = false)]
        public double? Vwap { get; set; }

        /// <summary> Gets or Sets HighPrice </summary>
        [DataMember(Name = "highPrice", EmitDefaultValue = false)]
        public double? HighPrice { get; set; }

        /// <summary> Gets or Sets LowPrice </summary>
        [DataMember(Name = "lowPrice", EmitDefaultValue = false)]
        public double? LowPrice { get; set; }

        /// <summary> Gets or Sets LastPrice </summary>
        [DataMember(Name = "lastPrice", EmitDefaultValue = false)]
        public double? LastPrice { get; set; }

        /// <summary> Gets or Sets LastPriceProtected </summary>
        [DataMember(Name = "lastPriceProtected", EmitDefaultValue = false)]
        public double? LastPriceProtected { get; set; }

        /// <summary> Gets or Sets LastTickDirection </summary>
        [DataMember(Name = "lastTickDirection", EmitDefaultValue = false)]
        public string LastTickDirection { get; set; }

        /// <summary> Gets or Sets LastChangePcnt </summary>
        [DataMember(Name = "lastChangePcnt", EmitDefaultValue = false)]
        public double? LastChangePcnt { get; set; }

        /// <summary> Gets or Sets BidPrice </summary>
        [DataMember(Name = "bidPrice", EmitDefaultValue = false)]
        public double? BidPrice { get; set; }

        /// <summary> Gets or Sets MidPrice </summary>
        [DataMember(Name = "midPrice", EmitDefaultValue = false)]
        public double? MidPrice { get; set; }

        /// <summary> Gets or Sets AskPrice </summary>
        [DataMember(Name = "askPrice", EmitDefaultValue = false)]
        public double? AskPrice { get; set; }

        /// <summary> Gets or Sets ImpactBidPrice </summary>
        [DataMember(Name = "impactBidPrice", EmitDefaultValue = false)]
        public double? ImpactBidPrice { get; set; }

        /// <summary> Gets or Sets ImpactMidPrice </summary>
        [DataMember(Name = "impactMidPrice", EmitDefaultValue = false)]
        public double? ImpactMidPrice { get; set; }

        /// <summary> Gets or Sets ImpactAskPrice </summary>
        [DataMember(Name = "impactAskPrice", EmitDefaultValue = false)]
        public double? ImpactAskPrice { get; set; }

        /// <summary> Gets or Sets HasLiquidity </summary>
        [DataMember(Name = "hasLiquidity", EmitDefaultValue = false)]
        public bool? HasLiquidity { get; set; }

        /// <summary> Gets or Sets OpenInterest </summary>
        [DataMember(Name = "openInterest", EmitDefaultValue = false)]
        public decimal? OpenInterest { get; set; }

        /// <summary> Gets or Sets OpenValue </summary>
        [DataMember(Name = "openValue", EmitDefaultValue = false)]
        public decimal? OpenValue { get; set; }

        /// <summary> Gets or Sets FairMethod </summary>
        [DataMember(Name = "fairMethod", EmitDefaultValue = false)]
        public string FairMethod { get; set; }

        /// <summary> Gets or Sets FairBasisRate </summary>
        [DataMember(Name = "fairBasisRate", EmitDefaultValue = false)]
        public double? FairBasisRate { get; set; }

        /// <summary> Gets or Sets FairBasis </summary>
        [DataMember(Name = "fairBasis", EmitDefaultValue = false)]
        public double? FairBasis { get; set; }

        /// <summary> Gets or Sets FairPrice </summary>
        [DataMember(Name = "fairPrice", EmitDefaultValue = false)]
        public double? FairPrice { get; set; }

        /// <summary> Gets or Sets MarkMethod </summary>
        [DataMember(Name = "markMethod", EmitDefaultValue = false)]
        public string MarkMethod { get; set; }

        /// <summary> Gets or Sets MarkPrice </summary>
        [DataMember(Name = "markPrice", EmitDefaultValue = false)]
        public double? MarkPrice { get; set; }

        /// <summary> Gets or Sets IndicativeTaxRate </summary>
        [DataMember(Name = "indicativeTaxRate", EmitDefaultValue = false)]
        public double? IndicativeTaxRate { get; set; }

        /// <summary> Gets or Sets IndicativeSettlePrice </summary>
        [DataMember(Name = "indicativeSettlePrice", EmitDefaultValue = false)]
        public double? IndicativeSettlePrice { get; set; }

        /// <summary> Gets or Sets OptionUnderlyingPrice </summary>
        [DataMember(Name = "optionUnderlyingPrice", EmitDefaultValue = false)]
        public double? OptionUnderlyingPrice { get; set; }

        /// <summary> Gets or Sets SettledPrice </summary>
        [DataMember(Name = "settledPrice", EmitDefaultValue = false)]
        public double? SettledPrice { get; set; }

        /// <summary> Gets or Sets Timestamp </summary>
        [DataMember(Name = "timestamp", EmitDefaultValue = false)]
        public DateTime? Timestamp { get; set; }
    }
}