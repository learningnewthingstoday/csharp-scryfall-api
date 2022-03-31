using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MagicAPI
{
	public class Models
	{
		public class ImageUris
		{
			[JsonProperty("small")] public string Small;
			[JsonProperty("normal")] public string Normal;
			[JsonProperty("large")] public string Large;
			[JsonProperty("png")] public string Png;
			[JsonProperty("art_crop")] public string ArtCrop;
			[JsonProperty("border_crop")] public string BorderCrop;
		}

		public class Legalities
		{
			[JsonProperty("standard")] public string Standard;
			[JsonProperty("future")] public string Future;
			[JsonProperty("historic")] public string Historic;
			[JsonProperty("gladiator")] public string Gladiator;
			[JsonProperty("pioneer")] public string Pioneer;
			[JsonProperty("modern")] public string Modern;
			[JsonProperty("legacy")] public string Legacy;
			[JsonProperty("pauper")] public string Pauper;
			[JsonProperty("vintage")] public string Vintage;
			[JsonProperty("penny")] public string Penny;
			[JsonProperty("commander")] public string Commander;
			[JsonProperty("brawl")] public string Brawl;
			[JsonProperty("historicbrawl")] public string Historicbrawl;
			[JsonProperty("alchemy")] public string Alchemy;
			[JsonProperty("paupercommander")] public string Paupercommander;
			[JsonProperty("duel")] public string Duel;
			[JsonProperty("oldschool")] public string Oldschool;
			[JsonProperty("premodern")] public string Premodern;
		}

		public class Prices
		{
			[JsonProperty("usd")] public string Usd;
			[JsonProperty("usd_foil")] public object UsdFoil;
			[JsonProperty("usd_etched")] public object UsdEtched;
			[JsonProperty("eur")] public string Eur;
			[JsonProperty("eur_foil")] public object EurFoil;
			[JsonProperty("tix")] public object Tix;
		}

		public class RelatedUris
		{
			[JsonProperty("gatherer")] public string Gatherer;
			[JsonProperty("tcgplayer_infinite_articles")] public string TcgplayerInfiniteArticles;
			[JsonProperty("tcgplayer_infinite_decks")] public string TcgplayerInfiniteDecks;
			[JsonProperty("edhrec")] public string Edhrec;
			[JsonProperty("mtgtop8")] public string Mtgtop8;
		}

		public class PurchaseUris
		{
			[JsonProperty("tcgplayer")] public string Tcgplayer;
			[JsonProperty("cardmarket")] public string Cardmarket;
			[JsonProperty("cardhoarder")] public string Cardhoarder;
		}

		public class Card
		{
			[JsonProperty("object")] public string Object;
			[JsonProperty("id")] public string Id;
			[JsonProperty("oracle_id")] public string OracleId;
			[JsonProperty("multiverse_ids")] public List<int> MultiverseIds;
			[JsonProperty("tcgplayer_id")] public int TcgplayerId;
			[JsonProperty("cardmarket_id")] public int CardmarketId;
			[JsonProperty("name")] public string Name;
			[JsonProperty("lang")] public string Lang;
			[JsonProperty("released_at")] public string ReleasedAt;
			[JsonProperty("uri")] public string Uri;
			[JsonProperty("scryfall_uri")] public string ScryfallUri;
			[JsonProperty("layout")] public string Layout;
			[JsonProperty("highres_image")] public bool HighresImage;
			[JsonProperty("image_status")] public string ImageStatus;
			[JsonProperty("image_uris")] public ImageUris ImageUris;
			[JsonProperty("mana_cost")] public string ManaCost;
			[JsonProperty("cmc")] public double Cmc;
			[JsonProperty("type_line")] public string TypeLine;
			[JsonProperty("oracle_text")] public string OracleText;
			[JsonProperty("power")] public string Power;
			[JsonProperty("toughness")] public string Toughness;
			[JsonProperty("colors")] public List<string> Colors;
			[JsonProperty("color_identity")] public List<string> ColorIdentity;
			[JsonProperty("keywords")] public List<object> Keywords;
			[JsonProperty("legalities")] public Legalities Legalities;
			[JsonProperty("games")] public List<string> Games;
			[JsonProperty("reserved")] public bool Reserved;
			[JsonProperty("foil")] public bool Foil;
			[JsonProperty("nonfoil")] public bool Nonfoil;
			[JsonProperty("finishes")] public List<string> Finishes;
			[JsonProperty("oversized")] public bool Oversized;
			[JsonProperty("promo")] public bool Promo;
			[JsonProperty("reprint")] public bool Reprint;
			[JsonProperty("variation")] public bool Variation;
			[JsonProperty("set_id")] public string SetId;
			[JsonProperty("set")] public string Set;
			[JsonProperty("set_name")] public string SetName;
			[JsonProperty("set_type")] public string SetType;
			[JsonProperty("set_uri")] public string SetUri;
			[JsonProperty("set_search_uri")] public string SetSearchUri;
			[JsonProperty("scryfall_set_uri")] public string ScryfallSetUri;
			[JsonProperty("rulings_uri")] public string RulingsUri;
			[JsonProperty("prints_search_uri")] public string PrintsSearchUri;
			[JsonProperty("collector_number")] public string CollectorNumber;
			[JsonProperty("digital")] public bool Digital;
			[JsonProperty("rarity")] public string Rarity;
			[JsonProperty("card_back_id")] public string CardBackId;
			[JsonProperty("artist")] public string Artist;
			[JsonProperty("artist_ids")] public List<string> ArtistIds;
			[JsonProperty("illustration_id")] public string IllustrationId;
			[JsonProperty("border_color")] public string BorderColor;
			[JsonProperty("frame")] public string Frame;
			[JsonProperty("full_art")] public bool FullArt;
			[JsonProperty("textless")] public bool Textless;
			[JsonProperty("booster")] public bool Booster;
			[JsonProperty("story_spotlight")] public bool StorySpotlight;
			[JsonProperty("edhrec_rank")] public int EdhrecRank;
			[JsonProperty("prices")] public Prices Prices;
			[JsonProperty("related_uris")] public RelatedUris RelatedUris;
			[JsonProperty("purchase_uris")] public PurchaseUris PurchaseUris;
			public string pictureBoxName;
			public string imageSrc;
		}
	}
}
