using System;
using System.Collections.Generic;

public class HandlingItemCharge
{
    public bool itemBulky { get; set; }
}

public class Tcin
{
    public string tcin { get; set; }
    public HandlingItemCharge handlingItemCharge { get; set; }
}

public class BulkShip
{
    public List<Tcin> tcins { get; set; }
}

public class Type
{
    public string appliedTo { get; set; }
    public string description { get; set; }
}

public class Callout
{
    public string text { get; set; }
    public Type type { get; set; }
}

public class Promotion
{
    public string subscriptionShippingMessage { get; set; }
    public Callout callout { get; set; }
    public List<object> promotionList { get; set; }
}

public class RatingDistribution
{
    public int Count { get; set; }
    public int RatingValue { get; set; }
}

public class SecondaryRatingsAverages
{
}

public class CoreStats
{
    public double AverageOverallRating { get; set; }
    public int RatingReviewTotal { get; set; }
    public int TotalReviewCount { get; set; }
    public int RatingsOnlyReviewCount { get; set; }
    public List<RatingDistribution> RatingDistribution { get; set; }
    public int RecommendedCount { get; set; }
    public int NotRecommendedCount { get; set; }
    public List<object> SecondaryRatingsAveragesOrder { get; set; }
    public SecondaryRatingsAverages SecondaryRatingsAverages { get; set; }
    public int OverallRatingRange { get; set; }
}

public class ExpertReviewContentMetadata
{
    public string url { get; set; }
    public DateTime lastUpdated { get; set; }
    public string vendor { get; set; }
    public string partNumber { get; set; }
}

public class __invalid_type__13860428
{
    public CoreStats coreStats { get; set; }
    public List<object> photoInfoList { get; set; }
    public List<object> secondaryRatingFields { get; set; }
    public List<ExpertReviewContentMetadata> expertReviewContentMetadata { get; set; }
}

public class Result
{
    public __invalid_type__13860428 __invalid_name__13860428 { get; set; }
}

public class RatingAndReviewStatistics
{
    public bool hasErrors { get; set; }
    public Result result { get; set; }
}

public class QuestionAnswerStatistics
{
    public string productId { get; set; }
    public int questionCount { get; set; }
}

public class RatingAndReviewReviews
{
    public bool hasErrors { get; set; }
    public int offset { get; set; }
    public int totalResults { get; set; }
    public int limit { get; set; }
    public int duration { get; set; }
}

public class AvailableToPromiseNetwork
{
    public string product_id { get; set; }
    public string id_type { get; set; }
    public double available_to_promise_quantity { get; set; }
    public DateTime street_date { get; set; }
    public string availability { get; set; }
    public double online_available_to_promise_quantity { get; set; }
    public double stores_available_to_promise_quantity { get; set; }
    public string availability_status { get; set; }
    public List<object> multichannel_options { get; set; }
    public bool is_infinite_inventory { get; set; }
    public string loyalty_availability_status { get; set; }
    public DateTime loyalty_purchase_start_date_time { get; set; }
    public bool is_loyalty_purchase_enabled { get; set; }
    public bool is_out_of_stock_in_all_store_locations { get; set; }
    public bool is_out_of_stock_in_all_online_locations { get; set; }
}

public class ListPrice
{
    public bool @null { get; set; }
    public double price { get; set; }
    public string formattedPrice { get; set; }
    public string priceType { get; set; }
    public int maxPrice { get; set; }
    public int minPrice { get; set; }
}

public class OfferPrice
{
    public bool @null { get; set; }
    public long startDate { get; set; }
    public double price { get; set; }
    public string eyebrow { get; set; }
    public string formattedPrice { get; set; }
    public double saveDollar { get; set; }
    public string priceType { get; set; }
    public long endDate { get; set; }
    public int maxPrice { get; set; }
    public int savePercent { get; set; }
    public int minPrice { get; set; }
}

public class Price
{
    public string partNumber { get; set; }
    public ListPrice listPrice { get; set; }
    public OfferPrice offerPrice { get; set; }
    public string ppu { get; set; }
    public string mapPriceFlag { get; set; }
    public string channelAvailability { get; set; }
}

public class BundleComponents
{
}

public class ProductDescription
{
    public string title { get; set; }
    public string downstream_description { get; set; }
    public List<string> bullet_description { get; set; }
}

public class ContentLabel
{
    public string image_url { get; set; }
}

public class Image
{
    public string base_url { get; set; }
    public string primary { get; set; }
    public List<ContentLabel> content_labels { get; set; }
}

public class SalesClassificationNode
{
    public string node_id { get; set; }
}

public class Enrichment
{
    public List<Image> images { get; set; }
    public List<SalesClassificationNode> sales_classification_nodes { get; set; }
}

public class Handling
{
}

public class RecallCompliance
{
    public bool is_product_recalled { get; set; }
}

public class TaxCategory
{
    public string tax_class { get; set; }
    public int tax_code_id { get; set; }
    public string tax_code { get; set; }
}

public class DisplayOption
{
    public bool is_size_chart { get; set; }
}

public class Fulfillment
{
    public bool is_po_box_prohibited { get; set; }
    public string po_box_prohibited_message { get; set; }
    public double box_percent_filled_by_volume { get; set; }
    public double box_percent_filled_by_weight { get; set; }
    public double box_percent_filled_display { get; set; }
}

public class PackageDimensions
{
    public string weight { get; set; }
    public string weight_unit_of_measure { get; set; }
    public string width { get; set; }
    public string depth { get; set; }
    public string height { get; set; }
    public string dimension_unit_of_measure { get; set; }
}

public class EnvironmentalSegmentation
{
    public bool is_hazardous_material { get; set; }
    public bool has_lead_disclosure { get; set; }
}

public class Manufacturer
{
}

public class ProductVendor
{
    public string id { get; set; }
    public string manufacturer_style { get; set; }
    public string vendor_name { get; set; }
}

public class ItemType
{
    public string category_type { get; set; }
    public int type { get; set; }
    public string name { get; set; }
}

public class ProductClassification
{
    public string product_type { get; set; }
    public string product_type_name { get; set; }
    public string item_type_name { get; set; }
    public ItemType item_type { get; set; }
}

public class ProductBrand
{
    public string brand { get; set; }
    public string manufacturer_brand { get; set; }
    public string facet_id { get; set; }
}

public class Attributes
{
    public string gift_wrapable { get; set; }
    public string has_prop65 { get; set; }
    public string is_hazmat { get; set; }
    public string manufacturing_brand { get; set; }
    public int max_order_qty { get; set; }
    public string street_date { get; set; }
    public string media_format { get; set; }
    public string merch_class { get; set; }
    public int merch_classid { get; set; }
    public int merch_subclass { get; set; }
    public string return_method { get; set; }
    public string ship_to_restriction { get; set; }
}

public class ReturnPolicies
{
    public string user { get; set; }
    public string policyDays { get; set; }
    public string guestMessage { get; set; }
}

public class Packaging
{
    public bool is_retail_ticketed { get; set; }
}

public class Item
{
    public string tcin { get; set; }
    public BundleComponents bundle_components { get; set; }
    public string dpci { get; set; }
    public string upc { get; set; }
    public ProductDescription product_description { get; set; }
    public string buy_url { get; set; }
    public Enrichment enrichment { get; set; }
    public string return_method { get; set; }
    public Handling handling { get; set; }
    public RecallCompliance recall_compliance { get; set; }
    public TaxCategory tax_category { get; set; }
    public DisplayOption display_option { get; set; }
    public Fulfillment fulfillment { get; set; }
    public PackageDimensions package_dimensions { get; set; }
    public EnvironmentalSegmentation environmental_segmentation { get; set; }
    public Manufacturer manufacturer { get; set; }
    public List<ProductVendor> product_vendors { get; set; }
    public ProductClassification product_classification { get; set; }
    public ProductBrand product_brand { get; set; }
    public string item_state { get; set; }
    public List<object> specifications { get; set; }
    public Attributes attributes { get; set; }
    public string country_of_origin { get; set; }
    public string relationship_type_code { get; set; }
    public bool subscription_eligible { get; set; }
    public List<object> ribbons { get; set; }
    public List<object> tags { get; set; }
    public string ship_to_restriction { get; set; }
    public string estore_item_status_code { get; set; }
    public bool is_proposition_65 { get; set; }
    public ReturnPolicies return_policies { get; set; }
    public bool gifting_enabled { get; set; }
    public Packaging packaging { get; set; }
}

public class CircleOffers
{
    public bool universal_offer_exists { get; set; }
    public bool non_universal_offer_exists { get; set; }
}

public class Product
{
    public BulkShip bulk_ship { get; set; }
    public Promotion promotion { get; set; }
    public RatingAndReviewStatistics rating_and_review_statistics { get; set; }
    public QuestionAnswerStatistics question_answer_statistics { get; set; }
    public RatingAndReviewReviews rating_and_review_reviews { get; set; }
    public AvailableToPromiseNetwork available_to_promise_network { get; set; }
    public Price price { get; set; }
    public Item item { get; set; }
    public CircleOffers circle_offers { get; set; }
}

public class ProductResponseData
{
    public Product product { get; set; }
}

public class CurrentPrice
{
    public double value { get; set; }
    public string currency_code { get; set; }
}
public class ProductObject
{
    public int id { get; set; }
    public string name { get; set; }
    public CurrentPrice current_price { get; set; }
}