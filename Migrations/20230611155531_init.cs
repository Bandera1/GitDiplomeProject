using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DiplomeProject.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductStatuses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Article = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    ProducerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DiscountPercent = table.Column<float>(type: "real", nullable: false),
                    WeightInKilogram = table.Column<float>(type: "real", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Producers_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "ProductStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b7b0b1b7-34ef-4534-b92c-d1599dffc86f", "4c0afc8b-b2fd-4907-bc18-ba6c682fbd8a", "Admin", null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "category1", "Засоби для прання" },
                    { "category2", "Порошки для миття посуду" },
                    { "category3", "Засоби для прибирання" },
                    { "category4", "Засоби для кухні" }
                });

            migrationBuilder.InsertData(
                table: "Producers",
                columns: new[] { "Id", "Country", "Name", "Rating" },
                values: new object[,]
                {
                    { "ariel01", "Germany", "Ariel", 5 },
                    { "Bonus03", "France", "Bonus", 5 },
                    { "Denkmit05", "Czech", "Denkmit", 5 },
                    { "Domestos04", "United Kingdom", "Domestos", 5 },
                    { "W502", "Germany", "W5", 5 }
                });

            migrationBuilder.InsertData(
                table: "ProductStatuses",
                columns: new[] { "Id", "StatusCode", "StatusName" },
                values: new object[,]
                {
                    { "avaliable", 0, "В наявності" },
                    { "notAvaliable", 2, "Немає в наявності" },
                    { "runOut", 1, "Закінчується" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Article", "CategoryId", "Description", "DiscountPercent", "Name", "PhotoPath", "Price", "ProducerId", "StatusId", "WeightInKilogram" },
                values: new object[,]
                {
                    { "12931cb8-d606-47e1-8a05-7898c5663e97", "MY635729", "category3", "Гель для туалету Domestos WC Gel — це надзвичайно густий засіб для чищення унітазів для економічного використання та ідеальної чистоти та гігієни. \r\n\r\nУнікальна дозувальна насадка Domestos дозволяє рівномірно розподіляє гель навіть у важкодоступних місцях. Він видаляє стійкі забруднення та відкладення вапняного нальоту, іржі та утворює захисний щит від утворення нового вапняного нальоту. \r\n\r\nЗасіб для чищення Domestos WC Gel наповнює ароматом океану і гарантує інтенсивну свіжість. Забезпечує гігієнічну та довготривалу чистоту та надає унітазу блиску та білизни.", 8f, "Гель для чищення унітазу Domestos Zero WC Gel Blue 750 мл", "/product14", 104f, "Domestos04", "avaliable", 0.75f },
                    { "15e741f5-6206-4063-828a-fb139c98c34c", "GT018896", "category3", "Універсальна рідина для прибирання W5 Eco ідеально підходить для щоденного догляду за різними типами поверхонь, що миються, включаючи підлогу, стіни і плитку. Засіб містить поверхнево-активні речовини рослинного походження. Ефективне прибирання із турботою про навколишнє середовище!\r\n\r\nЕкологічний миючий засіб W5 Eco призначений для всіх видів покриттів, а саме кахель, керамограніт, ламінат, пластик, вініл, лінолеум та ін.\r\n\r\nW5 Eco забезпечує ідеальну чистоту всіх поверхонь без тертя та надмірних зусиль та залишає легкий аромат свіжості.", 0f, "Засіб для прибирання W5 Eco універсальний екологічний 1,25 л", "/product8", 80f, "W502", "avaliable", 1.25f },
                    { "1d791781-812d-4f57-a42a-af35436ac137", "HP344397", "category2", "Унікальні капсули для прання кольорових речей Ariel Professional original від торгової марки Ariel подарують вашим речам неперевершену чистоту! Завдяки вмісту активних компонентів засіб чудово справляється навіть зі складними плямами на одязі, зберігаючи при цьому початкову насиченість кольору.\r\n\r\nКапсули для прання Ariel Professional original мають унікальну багатокамерну структуру, що означає, що інгредієнти відокремлені один від одного та не з'єднуються один з одним до початку прання, завдяки чому забезпечують надзвичайно концентровану пральну здатність. Інноваційне покриття капсул для прання Ariel повністю розчиняється при контакті з водою, вивільняючи спеціальні формули, що дозволяють видаляти різні види плям.\r\n\r\nКапсули Ariel – найкращий засіб у рідкій формі, що містить необхідну кількість окремих інгредієнтів. Цей засіб є у 3 рази більш концентрованим у порівнянні з іншими пральними засобами. Його перевагою є відсутність у складі фосфатів, що робить використання капсул абсолютно безпечним. Після прання ваші речі пахнуть свіжістю.", 0f, "Капсули для прання Ariel Professional original 80 шт", "/product2", 1282f, "ariel01", "runOut", 1f },
                    { "37c2f224-5515-47e8-a2c9-e7744705bbf9", "EU303471", "category4", "Набір для кухні BONUS Kitchen Smart Pack", 11f, "Набір для кухні BONUS Kitchen Smart Pack", "/product12", 208f, "Bonus03", "avaliable", 0.1f },
                    { "41cbc7bf-45d2-401c-b7a2-615130a3dbe6", "DM294647", "category3", "Засіб для очищення ламінату та пробкових підлог від Denkmit має формулу швидкого висихання, а також спеціальний захист стиків від вологи та здуття. Підходить для ламінату, пробки, вінілу та лінолеуму.\r\n\r\n*Упаковка містить не менше 70% переробленого вмісту.", 0f, "Засіб для миття ламінату Denkmit 1л", "/product19", 66f, "Denkmit05", "avaliable", 1f },
                    { "4249c221-181c-4614-bd93-806a05278082", "HP921552", "category1", "Універсальні капсули для прання Ariel All-in-1 забезпечують високу ефективність прання та протидіють широкому спектру плям. Капсули складаються з окремих камери, які вивільняють інгредієнти лише тоді, коли вони потрібні під час процесу прання. Інноваційна оболонка капсули Ariel All-in-1 повністю розчиняється при контакті з водою і є біологічно розкладною. \r\n\r\nНайкращий рідкий миючий засіб від Ariel з оптимальним дозуванням : 1 капсула на 1 цикл прання. Помістіть капсулу в барабан, а потім одяг зверху, щоб ефективно використовувати продукт.", 0f, "Капсули для прання Ariel All-in-1 універсальні 42 шт", "/product5", 335f, "ariel01", "notAvaliable", 5.45f },
                    { "50ba34c9-2888-47bb-ac72-948a3e0c7f5d", "DM485915", "category4", "Таблетки Denkmit проти вапняного нальоту мают силу подвійної дії: вони забезпечують надійний захист від вапняного нальоту як для машини, так і для білизни, а завдяки формулі захисту від бруду підтримують машину в чистоті. Регулярне використання засобу продовжить термін служби вашої пральної машини. Крім того, ви заощаджуєте миючий засіб, оскільки при використанні таблеток проти вапняного нальоту вам потрібно дозувати миючий засіб лише для діапазону жорсткості м’якої води – незалежно від того, наскільки жорстка ваша вода. ", 0f, "Засіб від накипу Denkmit у таблетках 60 шт", "/product17", 316f, "Denkmit05", "runOut", 2.5f },
                    { "82f29bb2-de09-4102-8b5e-207ab65ea22b", "HP344410", "category2", "Унікальні капсули для прання кольорових речей Ariel Professional color від торгової марки Ariel подарують вашим речам неперевершену чистоту! Завдяки вмісту активних компонентів засіб чудово справляється навіть зі складними плямами на одязі, зберігаючи при цьому початкову насиченість кольору.\r\n\r\nКапсули для прання Ariel Professional color мають унікальну багатокамерну структуру, що означає, що інгредієнти відокремлені один від одного та не з'єднуються один з одним до початку прання, завдяки чому забезпечують надзвичайно концентровану пральну здатність. Інноваційне покриття капсул для прання Ariel повністю розчиняється при контакті з водою, вивільняючи спеціальні формули, що дозволяють видаляти різні види плям.\r\n\r\nКапсули Ariel – найкращий засіб у рідкій формі, що містить необхідну кількість окремих інгредієнтів. Цей засіб є у 3 рази більш концентрованим у порівнянні з іншими пральними засобами. Його перевагою є відсутність у складі фосфатів, що робить використання капсул абсолютно безпечним. Після прання ваші речі пахнуть свіжістю.", 17f, "Капсули для прання Ariel Professional color 80 шт", "/product1", 1273f, "ariel01", "avaliable", 1f },
                    { "8448f1d5-962b-41ea-8950-0dece21551af", "MB116546", "category3", "Ефективний засіб для унітазів і пісуарів Domestos professional Original Pro Formula підходить для використання на фарфорових і глянсових поверхнях. Він входить у лінійку професійних сильнодіючих продуктів Pro Formula, розроблених для прибирання великих об'єктах: готелі, ресторани, навчальні заклади, торгові площі. Такий засіб з легкістю подолає побутові забруднення. Засіб видаляє сильні забруднення і вапняний наліт, відкладення, іржу, сечовий камінь і мильні розводи. Даний засіб є ефективним проти нальоту та інших забруднень, властивих сантехніці.", 0f, "Гель для чищення унітазу Domestos professional Original Pro Formula 750 мл", "/product13", 144f, "Domestos04", "notAvaliable", 0.75f },
                    { "a561e284-f6dd-4c2a-aa06-df2bf4d02102", "SV536988", "category1", "Пральний порошок Ariel Аква-Пудра Дотик свіжості Lenor автомат 5,4 кг", 15f, "Пральний порошок Ariel Аква-Пудра Дотик свіжості Lenor автомат 5,4 кг", "/product4", 585f, "ariel01", "avaliable", 5.45f },
                    { "bf8d5715-a11a-4e57-8e80-e2e309e15051", "MB813742", "category3", "Універсальний миючий засіб Domestos professional Pine Fresh Pro Formula з ароматом Хвої з дезінфікуючим ефектом для миття підлоги, туалету, раковин, ванн, стоків, підлоги та приладів у медичних закладах, санітарних приміщеннях, будинках у ресторанах та готелях тепер простіше та ефективніше. Завдяки густій консистенції засіб довше прилипає до поверхні, що очищається і більш ефективно видаляє забруднення. Відмінно підходить для місць, де важлива чистота та стерильність, і де щодня люди або готуються їжа.", 0f, "Гель для чищення унітазу Domestos professional Pine Fresh Pro Formula 5 л", "/product16", 403f, "Domestos04", "notAvaliable", 5f },
                    { "c0ce1483-f2ac-496e-9d87-f8481eb25520", "MB813759", "category3", "Засіб для чищення Domestos Citros Fresh Pro Formula \"Лимонна свіжість\" є універсальним. Він запобігає повторній появі грибка, надає дезінфікуючу дію, видаляє всі відомі мікроби. Достатньо невелику кількість засобу нанести на ганчірку або губку, щоб повністю продезінфікувати та очистити ванну кімнату та туалет. Чудово справляється із вапняним нальотом, видаляє плями будь-якого походження. Залишає після себе свіжий аромат лимона.", 0f, "Гель для чищення унітазу Domestos professional Citrus Fresh Pro Formula 5 л", "/product15", 447f, "Domestos04", "notAvaliable", 5f },
                    { "db634885-e457-42bb-b98c-6a6a07006b60", "EU052629", "category3", "BONUS + MicroMOP – це найефективніша абсорбуюча насадка для гладких поверхонь підлоги.\r\n\r\nОднією з найбільших проблем під час миття підлоги є складність по-справжньому зібрати бруд. Недостатньо просто протерти підлогу, тільки справді якісна насадка для швабри може дійсно зібрати, а не розтерти бруд по поверхні. MicroMOP може зробити це без зусиль, оскільки вона чудово поглинає вологу і стає достатньо масивною у вологому стані, тому не потрібно тиснути на підлогу під час прибирання. Одним рухом можна досягти дивовижної чистоти, а поверхня залишається майже сухою.", 0f, "Моп BONUS MicroMop Насадка для швабри мікрофібра 30*11*8 см (колір зелений+фіолет)", "/product11", 142f, "Bonus03", "notAvaliable", 1f },
                    { "db7e9e15-3fcb-451b-ae37-2f53b78104f2", "DM018889", "category3", "Гель антибактеріальний для очищення туалету \"ЕКО\" W5 Toilet Cleaner справляється із різними забрудненнями, наділений легкою антибактеріальною дією. Чистяча рідина не завдасть шкоди шкірі людини. Ваш унітаз просто сяятиме чистотою, як новий. На ньому не залишиться жодних розводів, а вашій туалетній кімнаті забезпечена гігієнічна чистота та свіжість. Ефективний і високоякісний засіб для чищення унітазів, ретельне миття забезпечує спеціальними компонентами, що містяться в засобі. Форма пляшки досить зручна для того, щоб наносити засіб навіть у «затишні куточки», такі як обідок унітазу. Засіб має приємний лимонний запах.", 20f, "Гель для чищення унітазу W5 Eco Lemon екологічний 1 л", "/product7", 59f, "W502", "runOut", 1f },
                    { "e02a1813-4cf3-4c96-8d85-8c2403a20516", "DM168423", "category3", "W5 спрей для чищення ванної з ароматом океану. Засіб призначений для миття плитки, стиків та сантехніки. Корисний скрізь, де є потреба гігієнічної чистоти. Без особливих труднощів позбавить від вапняного нальоту та грибка у ванній кімнаті. Завдяки W5 очищені поверхні надовго збережуть свій первісний вигляд і стануть чистими та блискучими. Виріб має зручний розпилювач, що створює активну піну. У складі лише натуральні компоненти рослинного та мінерального походження.", 0f, "Засіб для миття ванни W5 Kraft & Glanz Ocean спрей 1 л", "/product8", 80f, "W502", "avaliable", 1f },
                    { "ec5e7ea6-be19-4c9b-8b49-5c82ba510734", "DM178949", "category3", "Гель для чищення труб W5 1 л\r\n\r\nГель для очищення каналізаційних труб W5 ефективно усуває навіть стійкі засмічення, викликані волоссям, залишками харчових відходів, жиром або милом, і підходить для всіх поширених типів труб. Потужна високоефективна формула також усуває неприємні запахи для гігієнічної чистоти.", 0f, "Гель для чищення труб W5 1 л", "/product6", 76f, "W502", "avaliable", 1f },
                    { "eecbff61-813f-442d-862e-7caaa2094c98", "EU301491", "category3", "BONUS CottonMOP забезпечує блискучу чистоту підлоги!\r\n\r\nУ кожному помешканні є критичні точки для чистоти, в більшості випадків це не що інше, як підлога. Тому дуже важливо використовувати зручний та надійний інструмент, щоб мити підлогу. І це саме про BONUS CottonMOP. Найкраще використовувати його універсально для всіх видів підлогових поверхонь, на кухні, у ванній, вітальні або навіть використовувати на відкритому повітрі, на терасі або перед вхідними дверима.", 11f, "Моп BONUS Cotton Mop Насадка для швабри 30*9*6 см (бавовна) (L)", "/product10", 47.04f, "Bonus03", "avaliable", 1f },
                    { "ef85206f-a6fd-4420-94b0-35fe2578e77a", "EU052476", "category4", "БОНУС⁺ Чарівна губка для миття посуду – це ключ до чистоти кожної кухні та ванної кімнати. Зробіть прибирання незабутнім!\r\n\r\nКраса та додаткова ефективність — ці дві речі характеризують губку для миття посуду BONUS⁺ без подряпин, яка є незамінним аксесуаром для будь-якого стильного будинку.\r\n\r\nАбразивний шар без подряпин з веселим малюнком м'яко очищає забруднення. Як? Секрет криється у якісній губчастій піні та абразивному шарі без подряпин. Незалежно від того, чи це плями фарби на плитці чи на вікнах після фарбування, для губки BONUS + Magical немає неможливої місії.", 0f, "Губка BONUS Magical easy grip sponge scourer для миття посуду 2 шт", "/product9", 27.95f, "Bonus03", "avaliable", 0.1f },
                    { "f2204903-9189-49cf-af0e-22618166a19f", "DM289619", "category4", "Засіб Denkmit Супердія призначений для ефективного видалення жиру і нагару з кухонних поверхонь, плит, духовок, мікрохвильових печей та інших обладнаннях.", 12f, "Засіб для видалення жиру і нагару Denkmit Супердія 750 мл", "/product18", 720f, "Denkmit05", "avaliable", 0.75f },
                    { "fc7be537-04d5-45e6-afa1-e4e99662a079", "HP821748", "category1", "Універсальний плямовивідник-спрей Ariel Diamond Bright розроблений для видалення плям на кольорових, світлих і білих речах.\r\n\r\nЗасіб з технологією Oxifoam - активної кисневої піни - досягає помітного результату вже після першої обробки і прання. Рідина на основі унікальних інгредієнтів, усуває навіть найстійкіші жирові та інші плями від їжі і напоїв. Ariel Diamond Bright чудово впорається як зі свіжими, так і застарілими плямами.\r\n\r\nПлямовивідник Ariel не шкодить тканині, доглядаючи за волокнами під час прання. Завдяки інноваційній формулі всі кольори залишаються незмінними і зберігають свої початкові відтінки.", 0f, "Плямовивідник Ariel Diamond Bright для білого та кольорового 750 мл", "/product3", 157.25f, "ariel01", "avaliable", 0.75f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProducerId",
                table: "Products",
                column: "ProducerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StatusId",
                table: "Products",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Producers");

            migrationBuilder.DropTable(
                name: "ProductStatuses");
        }
    }
}
