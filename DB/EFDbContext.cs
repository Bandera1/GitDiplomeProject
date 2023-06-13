using DiplomeProject.DB.IdentityModels;
using DiplomeProject.DB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomeProject.DB
{
    public class EFDbContext : IdentityDbContext<DbUser, IdentityRole, string, IdentityUserClaim<string>,
    IdentityUserRole<string>, IdentityUserLogin<string>,
    IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductStatus> ProductStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Roles - 1
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin" });
          
            #region Category
            // Category - 4
            builder.Entity<Category>().HasData(
                new Category
                {
                    Id = "category1",
                    Name = "Засоби для прання"
                },
                new Category
                {
                    Id = "category2",
                    Name = "Порошки для миття посуду"
                },
                new Category
                {
                    Id = "category3",
                    Name = "Засоби для прибирання"
                },
                new Category
                {
                    Id = "category4",
                    Name = "Засоби для кухні"
                }       
             );
            #endregion

            // Producer - 5
            #region Producer
            builder.Entity<Producer>().HasData(
                new Producer
                {
                    Id = "ariel01",
                    Name = "Ariel",
                    Country = "Germany",
                    Rating = 5
                },
                new Producer
                {
                    Id = "W502",
                    Name = "W5",
                    Country = "Germany",
                    Rating = 5
                },
                new Producer
                {
                    Id = "Bonus03",
                    Name = "Bonus",
                    Country = "France",
                    Rating = 5
                },
                new Producer
                {
                    Id = "Domestos04",
                    Name = "Domestos",
                    Country = "United Kingdom",
                    Rating = 5
                },
                new Producer
                {
                    Id = "Denkmit05",
                    Name = "Denkmit",
                    Country = "Czech",
                    Rating = 5
                }
                );
            #endregion

            // Status - 3
            #region Status
            builder.Entity<ProductStatus>().HasData(
                new ProductStatus
                {
                    Id = "avaliable",
                    StatusCode = 0,
                    StatusName = "В наявності"
                },
                new ProductStatus
                {
                    Id = "runOut",
                    StatusCode = 1,
                    StatusName = "Закінчується"
                },
                new ProductStatus
                {
                    Id = "notAvaliable",
                    StatusCode = 2,
                    StatusName = "Немає в наявності"
                }
                );
            #endregion

            // Products - 19
            #region Products
            builder.Entity<Product>().HasData(
                #region Ariel
                new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Капсули для прання Ariel Professional color 80 шт",
                    Price = 1273,
                    ProducerId = "ariel01",
                    CategoryId = "category2",
                    StatusId = "avaliable",
                    WeightInKilogram = 1,
                    Article = "HP344410",
                    PhotoPath = "product1",
                    Description = "Унікальні капсули для прання кольорових речей Ariel Professional" +
                    " color від торгової марки Ariel подарують вашим речам неперевершену чистоту! Завдяки " +
                    "вмісту активних компонентів засіб чудово справляється навіть зі складними плямами на одязі, " +
                    "зберігаючи при цьому початкову насиченість кольору.\r\n\r\nКапсули для прання Ariel Professional " +
                    "color мають унікальну багатокамерну структуру, що означає, що інгредієнти відокремлені один від одного " +
                    "та не з'єднуються один з одним до початку прання, завдяки чому забезпечують надзвичайно концентровану пральну " +
                    "здатність. Інноваційне покриття капсул для прання Ariel повністю розчиняється при контакті з водою, вивільняючи спеціальні" +
                    " формули, що дозволяють видаляти різні види плям.\r\n\r\nКапсули Ariel – найкращий засіб у рідкій формі, що містить необхідну кількість окремих " +
                    "інгредієнтів. Цей засіб є у 3 рази більш концентрованим у порівнянні з іншими пральними засобами. Його перевагою є відсутність у складі фосфатів, " +
                    "що робить використання капсул абсолютно безпечним. Після прання ваші речі пахнуть свіжістю.",
                    DiscountPercent = 17
                },
                new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Капсули для прання Ariel Professional original 80 шт",
                    Price = 1282,
                    ProducerId = "ariel01",
                    CategoryId = "category2",
                    StatusId = "runOut",
                    WeightInKilogram = 1,
                    Article = "HP344397",
                    PhotoPath = "product2",
                    Description = "Унікальні капсули для прання кольорових речей Ariel Professional original від торгової марки Ariel подарують вашим речам неперевершену чистоту! Завдяки вмісту активних компонентів засіб чудово справляється навіть " +
                    "зі складними плямами на одязі, зберігаючи при цьому початкову насиченість кольору.\r\n\r\nКапсули для прання Ariel Professional original мають унікальну багатокамерну структуру, що означає, що інгредієнти відокремлені один від одного та " +
                    "не з'єднуються один з одним до початку прання, завдяки чому забезпечують надзвичайно концентровану пральну здатність. Інноваційне покриття капсул для прання Ariel повністю розчиняється при контакті з водою, вивільняючи спеціальні формули, що " +
                    "дозволяють видаляти різні види плям.\r\n\r\nКапсули Ariel – найкращий засіб у рідкій формі, що містить необхідну кількість окремих інгредієнтів. Цей засіб є у 3 рази більш концентрованим у порівнянні з іншими пральними засобами. Його перевагою є " +
                    "відсутність у складі фосфатів, що робить використання капсул абсолютно безпечним. Після прання ваші речі пахнуть свіжістю."
                },
                new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Плямовивідник Ariel Diamond Bright для білого та кольорового 750 мл",
                    Price = 157.25F,
                    ProducerId = "ariel01",
                    CategoryId = "category1",
                    StatusId = "avaliable",
                    WeightInKilogram = 0.75F,
                    Article = "HP821748",
                    PhotoPath = "product3",
                    Description = "Універсальний плямовивідник-спрей Ariel Diamond Bright розроблений для видалення плям на кольорових, світлих і білих речах.\r\n\r\n" +
                    "Засіб з технологією Oxifoam - активної кисневої піни - досягає помітного результату вже після першої обробки і прання. Рідина на основі унікальних " +
                    "інгредієнтів, усуває навіть найстійкіші жирові та інші плями від їжі і напоїв. Ariel Diamond Bright чудово впорається як зі свіжими, так і застарілими" +
                    " плямами.\r\n\r\nПлямовивідник Ariel не шкодить тканині, доглядаючи за волокнами під час прання. Завдяки інноваційній формулі всі кольори залишаються " +
                    "незмінними і зберігають свої початкові відтінки."
                },
                new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Пральний порошок Ariel Аква-Пудра Дотик свіжості Lenor автомат 5,4 кг",
                    Price = 585,
                    ProducerId = "ariel01",
                    CategoryId = "category1",
                    StatusId = "avaliable",
                    WeightInKilogram = 5.45F,
                    Article = "SV536988",
                    PhotoPath = "product4",
                    Description = "Пральний порошок Ariel Аква-Пудра Дотик свіжості Lenor автомат 5,4 кг",
                    DiscountPercent = 15
                },
                new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Капсули для прання Ariel All-in-1 універсальні 42 шт",
                    Price = 335,
                    ProducerId = "ariel01",
                    CategoryId = "category1",
                    StatusId = "notAvaliable",
                    WeightInKilogram = 5.45F,
                    Article = "HP921552",
                    PhotoPath = "product5",
                    Description = "Універсальні капсули для прання Ariel All-in-1 забезпечують високу ефективність прання та протидіють широкому спектру плям." +
                    " Капсули складаються з окремих камери, які вивільняють інгредієнти лише тоді, коли вони потрібні під час процесу прання. " +
                    "Інноваційна оболонка капсули Ariel All-in-1 повністю розчиняється при контакті з водою і є біологічно розкладною. " +
                    "\r\n\r\nНайкращий рідкий миючий засіб від Ariel з оптимальним дозуванням : 1 капсула на 1 цикл прання. Помістіть капсулу в барабан, а" +
                    " потім одяг зверху, щоб ефективно використовувати продукт."
                },
                #endregion
                #region W5
                new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Гель для чищення труб W5 1 л",
                    Price = 76,
                    ProducerId = "W502",
                    CategoryId = "category3",
                    StatusId = "avaliable",
                    WeightInKilogram = 1,
                    Article = "DM178949",
                    PhotoPath = "product6",
                    Description = "Гель для чищення труб W5 1 л\r\n\r\nГель для очищення каналізаційних труб W5 ефективно усуває навіть стійкі засмічення, " +
                    "викликані волоссям, залишками харчових відходів, жиром або милом, " +
                    "і підходить для всіх поширених типів труб. Потужна високоефективна формула також усуває неприємні запахи для гігієнічної чистоти."
                },
                new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Гель для чищення унітазу W5 Eco Lemon екологічний 1 л",
                    Price = 59,
                    ProducerId = "W502",
                    CategoryId = "category3",
                    StatusId = "runOut",
                    WeightInKilogram = 1,
                    Article = "DM018889",
                    PhotoPath = "product7",
                    Description = "Гель антибактеріальний для очищення туалету \"ЕКО\" W5 Toilet Cleaner справляється із різними забрудненнями, " +
                    "наділений легкою антибактеріальною дією. Чистяча рідина не завдасть шкоди шкірі людини. Ваш унітаз просто сяятиме чистотою, " +
                    "як новий. На ньому не залишиться жодних розводів, а вашій туалетній кімнаті забезпечена гігієнічна чистота та свіжість. " +
                    "Ефективний і високоякісний засіб для чищення унітазів, ретельне миття забезпечує спеціальними компонентами, що містяться в засобі. " +
                    "Форма пляшки досить зручна для того, щоб наносити засіб навіть у «затишні куточки», такі як обідок унітазу. Засіб має приємний " +
                    "лимонний запах.",
                    DiscountPercent = 20
                },
                new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Засіб для миття ванни W5 Kraft & Glanz Ocean спрей 1 л",
                    Price = 80,
                    ProducerId = "W502",
                    CategoryId = "category3",
                    StatusId = "avaliable",
                    WeightInKilogram = 1,
                    Article = "DM168423",
                    PhotoPath = "product8",
                    Description = "W5 спрей для чищення ванної з ароматом океану. Засіб призначений для миття плитки, стиків та сантехніки. " +
                    "Корисний скрізь, де є потреба гігієнічної чистоти. Без особливих труднощів позбавить від вапняного нальоту та грибка у ванній " +
                    "кімнаті. Завдяки W5 очищені поверхні надовго збережуть свій первісний вигляд і стануть чистими та блискучими. Виріб має зручний " +
                    "розпилювач, що створює активну піну. У складі лише натуральні компоненти рослинного та мінерального походження."
                },
                new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Засіб для прибирання W5 Eco універсальний екологічний 1,25 л",
                    Price = 80,
                    ProducerId = "W502",
                    CategoryId = "category3",
                    StatusId = "avaliable",
                    WeightInKilogram = 1.25F,
                    Article = "GT018896",
                    PhotoPath = "product8",
                    Description = "Універсальна рідина для прибирання W5 Eco ідеально підходить для щоденного догляду за різними типами поверхонь, " +
                    "що миються, включаючи підлогу, стіни і плитку. Засіб містить поверхнево-активні речовини рослинного походження. " +
                    "Ефективне прибирання із турботою про навколишнє середовище!\r\n\r\nЕкологічний миючий засіб W5 Eco призначений для всіх видів " +
                    "покриттів, а саме кахель, керамограніт, ламінат, пластик, вініл, лінолеум та ін.\r\n\r\nW5 Eco забезпечує ідеальну чистоту всіх " +
                    "поверхонь без тертя та надмірних зусиль та залишає легкий аромат свіжості."
                },
                #endregion
                #region Bonus
                new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Губка BONUS Magical easy grip sponge scourer для миття посуду 2 шт",
                    Price = 27.95F,
                    ProducerId = "Bonus03",
                    CategoryId = "category4",
                    StatusId = "avaliable",
                    WeightInKilogram = 0.1F,
                    Article = "EU052476",
                    PhotoPath = "product9",
                    Description = "БОНУС⁺ Чарівна губка для миття посуду – це ключ до чистоти кожної кухні та ванної кімнати. Зробіть прибирання незабутнім!\r\n\r\n" +
                    "Краса та додаткова ефективність — ці дві речі характеризують губку для миття посуду BONUS⁺ без подряпин, яка є незамінним аксесуаром для будь-якого стильного будинку." +
                    "\r\n\r\nАбразивний шар без подряпин з веселим малюнком м'яко очищає забруднення. Як? Секрет криється у якісній губчастій піні та абразивному шарі без подряпин. " +
                    "Незалежно від того, чи це плями фарби на плитці чи на вікнах після фарбування, для губки BONUS + Magical немає неможливої місії."
                },
                new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Моп BONUS Cotton Mop Насадка для швабри 30*9*6 см (бавовна) (L)",
                    Price = 47.04F,
                    ProducerId = "Bonus03",
                    CategoryId = "category3",
                    StatusId = "avaliable",
                    WeightInKilogram = 1,
                    Article = "EU301491",
                    PhotoPath = "product10",
                    Description = "BONUS CottonMOP забезпечує блискучу чистоту підлоги!\r\n\r\nУ кожному помешканні є критичні точки для чистоти, " +
                    "в більшості випадків це не що інше, як підлога. " +
                    "Тому дуже важливо використовувати зручний та надійний інструмент, щоб мити підлогу. " +
                    "І це саме про BONUS CottonMOP. " +
                    "Найкраще використовувати його універсально для всіх видів підлогових поверхонь, на кухні, у ванній, вітальні " +
                    "або навіть використовувати на відкритому повітрі, на терасі або перед вхідними дверима.",
                    DiscountPercent = 11
                },
                new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Моп BONUS MicroMop Насадка для швабри мікрофібра 30*11*8 см (колір зелений+фіолет)",
                    Price = 142,
                    ProducerId = "Bonus03",
                    CategoryId = "category3",
                    StatusId = "notAvaliable",
                    WeightInKilogram = 1,
                    Article = "EU052629",
                    PhotoPath = "product11",
                    Description = "BONUS + MicroMOP – це найефективніша абсорбуюча насадка для гладких поверхонь підлоги." +
                    "\r\n\r\nОднією з найбільших проблем під час миття підлоги є складність по-справжньому зібрати бруд. " +
                    "Недостатньо просто протерти підлогу, тільки справді якісна насадка для швабри може дійсно зібрати, а не розтерти бруд по поверхні. " +
                    "MicroMOP може зробити це без зусиль, оскільки вона чудово поглинає вологу і стає достатньо масивною у вологому стані, " +
                    "тому не потрібно тиснути на підлогу під час прибирання. Одним рухом можна досягти дивовижної чистоти, а поверхня залишається майже сухою."
                },
                new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Набір для кухні BONUS Kitchen Smart Pack",
                    Price = 208,
                    DiscountPercent = 11,
                    ProducerId = "Bonus03",
                    CategoryId = "category4",
                    StatusId = "avaliable",
                    WeightInKilogram = 0.1F,
                    Article = "EU303471",
                    PhotoPath = "product12",
                    Description = "Набір для кухні BONUS Kitchen Smart Pack"
                },
                #endregion
                #region Domestos
                new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Гель для чищення унітазу Domestos professional Original Pro Formula 750 мл",
                    Price = 144F,
                    ProducerId = "Domestos04",
                    CategoryId = "category3",
                    StatusId = "notAvaliable",
                    WeightInKilogram = 0.750F,
                    Article = "MB116546",
                    PhotoPath = "product13",
                    Description = "Ефективний засіб для унітазів і пісуарів Domestos professional Original Pro Formula підходить для використання на фарфорових " +
                    "і глянсових поверхнях. Він входить у лінійку професійних сильнодіючих продуктів Pro Formula, розроблених для прибирання великих об'єктах: " +
                    "готелі, ресторани, навчальні заклади, торгові площі. Такий засіб з легкістю подолає побутові забруднення. Засіб видаляє сильні забруднення і " +
                    "вапняний наліт, відкладення, іржу, " +
                    "сечовий камінь і мильні розводи. Даний засіб є ефективним проти нальоту та інших забруднень, властивих сантехніці."
                },
                new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Гель для чищення унітазу Domestos Zero WC Gel Blue 750 мл",
                    Price = 104,
                    DiscountPercent = 8,
                    ProducerId = "Domestos04",
                    CategoryId = "category3",
                    StatusId = "avaliable",
                    WeightInKilogram = 0.75F,
                    Article = "MY635729",
                    PhotoPath = "product14",
                    Description = "Гель для туалету Domestos WC Gel — це надзвичайно густий засіб для чищення унітазів для економічного використання та " +
                    "ідеальної чистоти та гігієни. \r\n\r\nУнікальна дозувальна насадка Domestos дозволяє рівномірно розподіляє гель навіть у важкодоступних " +
                    "місцях. Він видаляє стійкі забруднення та відкладення вапняного нальоту, іржі та утворює захисний щит від утворення нового вапняного нальоту." +
                    " \r\n\r\nЗасіб для чищення Domestos WC Gel наповнює ароматом океану і гарантує інтенсивну свіжість. Забезпечує гігієнічну та довготривалу чистоту " +
                    "та надає унітазу блиску та білизни."
                },
                new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Гель для чищення унітазу Domestos professional Citrus Fresh Pro Formula 5 л",
                    Price = 447,
                    ProducerId = "Domestos04",
                    CategoryId = "category3",
                    StatusId = "notAvaliable",
                    WeightInKilogram = 5,
                    Article = "MB813759",
                    PhotoPath = "product15",
                    Description = "Засіб для чищення Domestos Citros Fresh Pro Formula \"Лимонна свіжість\" є універсальним. " +
                    "Він запобігає повторній появі грибка, надає дезінфікуючу дію, видаляє всі відомі мікроби. Достатньо невелику " +
                    "кількість засобу нанести на ганчірку або губку, щоб повністю продезінфікувати та очистити ванну кімнату та туалет." +
                    " Чудово справляється із вапняним нальотом, видаляє плями будь-якого походження. Залишає після себе свіжий аромат лимона."
                },
                new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Гель для чищення унітазу Domestos professional Pine Fresh Pro Formula 5 л",
                    Price = 403,
                    ProducerId = "Domestos04",
                    CategoryId = "category3",
                    StatusId = "notAvaliable",
                    WeightInKilogram = 5,
                    Article = "MB813742",
                    PhotoPath = "product16",
                    Description = "Універсальний миючий засіб Domestos professional Pine Fresh Pro Formula з ароматом Хвої з дезінфікуючим " +
                    "ефектом для миття підлоги, туалету, раковин, ванн, стоків, підлоги та приладів у медичних закладах, санітарних приміщеннях, " +
                    "будинках у ресторанах та готелях тепер простіше та ефективніше. Завдяки густій консистенції засіб довше прилипає до поверхні, " +
                    "що очищається і більш ефективно видаляє забруднення. Відмінно підходить для місць, де важлива чистота та стерильність, " +
                    "і де щодня люди або готуються їжа."
                },
                #endregion
                #region Denkmit
                new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Засіб від накипу Denkmit у таблетках 60 шт",
                    Price = 316F,
                    ProducerId = "Denkmit05",
                    CategoryId = "category4",
                    StatusId = "runOut",
                    WeightInKilogram = 2.5F,
                    Article = "DM485915",
                    PhotoPath = "product17",
                    Description = "Таблетки Denkmit проти вапняного нальоту мают силу подвійної дії: вони забезпечують надійний захист від " +
                    "вапняного нальоту як для машини, так і для білизни, а завдяки формулі захисту від бруду підтримують машину в чистоті. " +
                    "Регулярне використання засобу продовжить термін служби вашої пральної машини. Крім того, ви заощаджуєте миючий засіб, " +
                    "оскільки при використанні таблеток проти вапняного нальоту вам потрібно дозувати миючий засіб лише для діапазону жорсткості " +
                    "м’якої води – незалежно від того, наскільки жорстка ваша вода. "
                },
                new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Засіб для видалення жиру і нагару Denkmit Супердія 750 мл",
                    Price = 720,
                    DiscountPercent = 12,
                    ProducerId = "Denkmit05",
                    CategoryId = "category4",
                    StatusId = "avaliable",
                    WeightInKilogram = 0.75F,
                    Article = "DM289619",
                    PhotoPath = "product18",
                    Description = "Засіб Denkmit Супердія призначений для ефективного видалення жиру і нагару з" +
                    " кухонних поверхонь, плит, духовок, мікрохвильових печей та інших обладнаннях."
                },
                new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Засіб для миття ламінату Denkmit 1л",
                    Price = 66,
                    ProducerId = "Denkmit05",
                    CategoryId = "category3",
                    StatusId = "avaliable",
                    WeightInKilogram = 1,
                    Article = "DM294647",
                    PhotoPath = "product19",
                    Description = "Засіб для очищення ламінату та пробкових підлог від Denkmit має формулу швидкого висихання, " +
                    "а також спеціальний захист стиків від вологи та здуття. Підходить для ламінату, пробки, вінілу та лінолеуму." +
                    "\r\n\r\n*Упаковка містить не менше 70% переробленого вмісту."
                }
                #endregion
               );

            #endregion
        }
    }
}
