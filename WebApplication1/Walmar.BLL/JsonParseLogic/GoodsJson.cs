using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walmar.BLL.JsonParseLogic
{

    public class GoodsReviewJ
    {
        public string status { get; set; }
        public object[] errors { get; set; }
        public Header header { get; set; }
        public Payload payload { get; set; }
    }

    public class Header
    {
        public Headerattributes headerAttributes { get; set; }
    }

    public class Headerattributes
    {
        public Tenant tenant { get; set; }
        public Server server { get; set; }
        public Context context { get; set; }
        public Timing timing { get; set; }
    }

    public class Tenant
    {
        public string WM_BU_ID { get; set; }
        public string WM_MART_ID { get; set; }
        public string WM_VERTICAL_ID { get; set; }
        public string WM_CHANNEL_ID { get; set; }
        public string WM_LOCALE_ID { get; set; }
    }

    public class Server
    {
        public string sha { get; set; }
        public string ver { get; set; }
        public string name { get; set; }
        public string dc { get; set; }
        public string env { get; set; }
    }

    public class Context
    {
        public bool access { get; set; }
        public string device { get; set; }
        public string browser { get; set; }
        public string topTxId { get; set; }
    }

    public class Timing
    {
        public Total total { get; set; }
    }

    public class Total
    {
        public int startOffset { get; set; }
        public int completeOffset { get; set; }
        public int elapsed { get; set; }
    }

    public class Payload
    {
        public float averageOverallRating { get; set; }
        public float roundedAverageOverallRating { get; set; }
        public float overallRatingRange { get; set; }
        public int totalReviewCount { get; set; }
        public int recommendedPercentage { get; set; }
        public int ratingValueOneCount { get; set; }
        public int ratingValueTwoCount { get; set; }
        public int ratingValueThreeCount { get; set; }
        public int ratingValueFourCount { get; set; }
        public int ratingValueFiveCount { get; set; }
        public int percentageOneCount { get; set; }
        public int percentageTwoCount { get; set; }
        public int percentageThreeCount { get; set; }
        public int percentageFourCount { get; set; }
        public int percentageFiveCount { get; set; }
        public int activePage { get; set; }
        public string activeSort { get; set; }
        public Activefilters activeFilters { get; set; }
        public Pagination pagination { get; set; }
        public Customerreview[] customerReviews { get; set; }
    }

    public class Activefilters
    {
    }

    public class Pagination
    {
        public int total { get; set; }
        public Page[] pages { get; set; }
        public Previous previous { get; set; }
        public Next next { get; set; }
        public string currentSpan { get; set; }
    }

    public class Previous
    {
        public int num { get; set; }
        public bool gap { get; set; }
        public bool active { get; set; }
        public string url { get; set; }
    }

    public class Next
    {
        public int num { get; set; }
        public bool gap { get; set; }
        public bool active { get; set; }
        public string url { get; set; }
    }

    public class Page
    {
        public int num { get; set; }
        public bool gap { get; set; }
        public bool active { get; set; }
        public string url { get; set; }
    }

    public class Customerreview
    {
        public string reviewId { get; set; }
        public string authorId { get; set; }
        public bool recommended { get; set; }
        public bool showRecommended { get; set; }
        public int negativeFeedback { get; set; }
        public int positiveFeedback { get; set; }
        public float rating { get; set; }
        public string reviewTitle { get; set; }
        public string reviewText { get; set; }
        public string reviewSubmissionTime { get; set; }
        public string userNickname { get; set; }
        public Badge[] badges { get; set; }
        public string userAge { get; set; }
        public string userGender { get; set; }
        public Userattributes userAttributes { get; set; }
        public object[] photos { get; set; }
        public object[] videos { get; set; }
        public string userLocation { get; set; }
    }

    public class Userattributes
    {
        public string Usage { get; set; }
        public string Ownership { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
    }

    public class Badge
    {
        public string badgeType { get; set; }
        public string id { get; set; }
        public string contentType { get; set; }
    }

    public class GoodsJson
    {
        public string PageType { get; set; }
        public string SubType { get; set; }
        public string ProductId { get; set; }
        public string ItemId { get; set; }
        public decimal Price { get; set; }
        public bool Preorder { get; set; }
        public bool Online { get; set; }
        public bool FreeShipping { get; set; }
        public bool InStore { get; set; }
        public string Query { get; set; }
        public string Brand { get; set; }
        public string CategoryPathId { get; set; }
        public string CategoryPathName { get; set; }
        public string Manufacturer { get; set; }
    }
}
