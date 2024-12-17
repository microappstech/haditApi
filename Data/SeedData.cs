using haditApi.Models;

using Microsoft.EntityFrameworkCore;

namespace haditApi.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            try
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    var scopedProvider = scope.ServiceProvider;
                    var options = scopedProvider.GetRequiredService<DbContextOptions<dbContext>>();

                    using (var context = new dbContext(options))
                    {
                        context.Database.EnsureCreated();

                        if (!context.Categories.Any())
                        {
                            List<Category> categories = new List<Category>()
                            {
                                new Category {Name="الإيمان والعقيدة"},
                                new Category {Name="الأخلاق والمعاملات"},
                                new Category {Name="العمل والأمانة"},
                                new Category {Name="الأسرة والعلاقات"},
                                new Category {Name="النصيحة والإرشاد"},
                                new Category {Name=" الآخرة والعقاب والثواب"},
                                new Category {Name="المسؤولية والقيادة"},
                                new Category {Name="الحلال والحرام"},

                            };
                            context.Categories.AddRange(categories);
                        }

                        if (!context.Hadites.Any())
                        {
                            List<Hadit> Hadites = new List<Hadit>()
                            {
                                new Hadit
                                {
                                    Content ="ية المنافق ثلاث إذا حدَّث كذّب، وإذا وعد أخلف، وإذا ائتمن خان",
                                    OnPublisher ="عن أبي هريرة، رواه الشيخان",
                                    CategoryId = 2,
                                },
                                new Hadit
                                {
                                    Content ="«أبغض الحلال إلى الله الطلاق».",
                                    OnPublisher ="عن ابن عمر، رواه أبو داود وابن ماجه",
                                    CategoryId = 3,
                                },
                                new Hadit
                                {
                                    Content ="«اتقوا الله واعدلوا في أولادكم».",
                                    OnPublisher ="(عن النعمان بن بشير، أخرجه الشيخان) ",
                                    CategoryId = 3,
                                },
                                new Hadit
                                {
                                    Content ="(عن النعمان بن بشير، أخرجه الشيخان)",
                                    OnPublisher ="(عن جابر، أخرجه مسلم)",
                                    CategoryId = 3,
                                },
                                new Hadit
                                {
                                    Content ="«اجتنبوا السبع الموبقات: الشرك بالله، والسحر، وقتل النفس التي حرَّم الله إلا بالحق، وأكل الربا وأكل مال اليتيم، والتولي يوم الزحف، وقذف المُحْصَنات الغافلات»",
                                    OnPublisher ="(عن أبي هريرة، أخرجه الشيخان)",
                                    CategoryId = 3,
                                },
                                new Hadit
                                {
                                    Content ="أحب الأعمال إلى الله، أدومها وإن قلّ",
                                    OnPublisher ="عن عائشة، رواه الشيخان",
                                    CategoryId = 3,
                                },
                                new Hadit
                                {
                                    Content ="«أحب الناس إلى الله تعالى يوم القيامة وأدناهم منه مجلسا، إمام عادل، وأبغض الناس إلى الله يوم القيامة وأبعدهم منه مجلسا، إمام جائر».",
                                    OnPublisher ="عن أبي سعيد، أخرجه الترمذي",
                                    CategoryId = 3,
                                },
                                new Hadit
                                {
                                    Content ="«البِرُّ حسن الخلق، والإثم ما حاك في صدرك وكرهت أن يطلع عليه الناس».",
                                    OnPublisher ="عن النوّاس بن سمعان، أخرجه مسلم",
                                    CategoryId = 3,
                                },
                                new Hadit
                                {
                                    Content ="«إذا استأذنت أحدَكم امرأتهُ إلى المسجد فلا يمنعها»",
                                    OnPublisher ="عن سالم عن أبيه، رواه مسلم",
                                    CategoryId = 3,
                                },
                                new Hadit
                                {
                                    Content ="إذا التقى المسلمان بسيفهما فقتل أحدهما صاحبه، فالقاتل والمقتول في النار»، قيل: يا رسول الله هذا القاتل فما بال المقتول؟ قال: «إنه كان حريصا على قتل صاحبه»",
                                    OnPublisher ="عن أبي بكرة، رواه الشيخان",
                                    CategoryId = 3,
                                },
                                new Hadit
                                {
                                    Content ="«إذا أُمَّ أحدكم الناس، فليخفف، فإن فيهم الصغير والكبير والضعيف والمريض وذا الحاجة، وإذا صلى لنفسه فليطوّل ما شاء».",
                                    OnPublisher ="عن أبي هريرة، رواه الشيخان",
                                    CategoryId = 3,
                                },
                                new Hadit
                                {
                                    Content ="«إذا تقاضى إليك رجلان، فلا تقض للأول حتى تسمع كلام الآخر، فسوف تدري كيف تقضي»",
                                    OnPublisher ="عن علِيّ رضي الله عنه، رواه أحمد وأبو داود والترمذي",
                                    CategoryId = 3,
                                },
                                new Hadit
                                {
                                    Content ="«إذا حكم الحاكم فاجتهد ثم أصاب، فله أجران، وإذا حكم فاجتهد ثم أخطأ فله أجر»",
                                    OnPublisher ="عن عمرو بن العاص: متفق عليه",
                                    CategoryId = 3,
                                },
                                new Hadit
                                {
                                    Content ="«إذا رأى أحدكم جنازة، فإن لم يكن ماشيا معها، فليقم حتى يخلفها أو تخلفه أو توضع من قبل أن تخلفه»",
                                    OnPublisher ="(عن عامر بن ربيعة، رواه البخاري) ",
                                    CategoryId = 3,
                                },
                                new Hadit
                                {
                                    Content = "«إذا مات ابن آدم، انقطع عنه عمله إلا من ثلاث: صدقة جارية، أو علم ينتفع به، أو ولد صالح يدعو له»",
                                    OnPublisher="عن مسلم عن أبي هريرة",
                                    CategoryId=3,
                                },
                                new Hadit
                                {
                                    Content = "«أربع مَن كنّ فيه، كان منافقا خالصا، ومَن كانت فيه خَلّة منهن، كانت فيه خلة من نفاق حتى يدعها: إذا حدَّثَ كَذَب، وإذا عاهد غدر، وإذا وعد أخلف، وإذا خاصم فجر»",
                                    OnPublisher = "عن عبد الله بن عمر، رواه الشيخان",
                                    CategoryId = 3,
                                },
                                new Hadit
                                {
                                    Content = "«ألا أنبئكم بأكبر الكبائر: الإشراك بالله، وعقوق الوالدين، وقول الزور»",
                                    OnPublisher = "عن علِيّ رضي الله عنه، رواه الشيخان",
                                    CategoryId = 3,
                                },
                                new Hadit
                                {
                                    Content = "«الإحسان أن تعبد الله كأنك تراه، فإن لم تكن تراه، فإنه يراك»",
                                    OnPublisher = "عن أبي هريرة، رواه الشيخان",
                                    CategoryId = 3,
                                },
                                new Hadit
                                {
                                    Content = "«الأرواح جنود مجَنَّدة، فما تعارف منها ائتلف وما تناكر منها اختلف»",
                                    OnPublisher = "عن أبي هريرة، رواه الشيخان",
                                    CategoryId = 3,
                                },
                                new Hadit
                                {
                                    Content = "«إنا لن نستعمل على عملنا من أراده»",
                                    OnPublisher = "عن أبي موسى، رواه الشيخان",
                                    CategoryId = 3,
                                },
                                new Hadit
                                {
                                    Content = "«انظروا إلى من هو أسفل منكم، ولا تنظروا إلى من هو فوقكم، فهو أجدر أن لا تزدروا نعمة الله عليكم»",
                                    OnPublisher = "عن أبي هريرة، متفق عليه",
                                    CategoryId = 3,
                                },
                                new Hadit
                                {
                                    Content = "«إن الله تعالى حرم عليكم عقوق الأمهات، ووأد البنات، ومنعا وهات، وكره لكم قيلا وقال، وكثرة السؤال وإضاعة المال»",
                                    OnPublisher = "عن المغيرة بن شعبة، رواه الشيخان",
                                    CategoryId = 3,
                                },
                                new Hadit
                                {
                                    Content = "«إن الله تعالى قد حرم على النار من قال لا إله إلا الله يبتغي بذلك وجه الله»",
                                    OnPublisher = "عن عتبان بن مالك، رواه الشيخان",
                                    CategoryId = 3,
                                },
                                new Hadit
                                {
                                    Content = "«إن الدعاء هو العبادة»",
                                    OnPublisher = "عن أبي هريرة، رواه الأربعة",
                                    CategoryId = 3,
                                },
                                new Hadit
                                {
                                    Content = "«إن الدين يُسر ولن يُشَادَّ الدين أحد إلا غلبه، فسددوا وقاربوا وأبشروا، واستعينوا بالغَدْوة والرّوحة وشيء من الدُّلْجة»",
                                    OnPublisher = "عن أبي هريرة، أخرجه البخاري",
                                    CategoryId = 3,
                                },
                                new Hadit
                                {
                                    Content = "«إن شر الناس عند الله منزلة يوم القيامة، الرجل يفضي إلى امرأته وتفضي إليه ثم ينشر سرها»",
                                    OnPublisher = "عن أبي سعيد الخدري، رواه مسلم",
                                    CategoryId = 3,
                                },
                                new Hadit
                                {
                                    Content = "«إن شر الناس منزلة عند الله يوم القيامة، هو مَنْ تركه الناس اتقاء فُحشه»",
                                    OnPublisher = "عن عائشة، رواه الشيخان",
                                    CategoryId = 3,
                                },
                                new Hadit
                                {
                                    Content = "«إنكم ستحرصون على الإمارة، وستكون ندامة يوم القيامة، فنعمت المرضعة وبئست الفاطمة»",
                                    OnPublisher = "عن أبي هريرة، رواه البخاري",
                                    CategoryId = 3,
                                },
                                new Hadit
                                {
                                    Content = "«إن الميت ليعذب ببكاء الحي»",
                                    OnPublisher = "عن عمر، رواه الشيخان",
                                    CategoryId = 3,
                                },
                                new Hadit
                                {
                                    Content = "«إنما الأعمال بالنيات وإنما لكل امرىء ما نوى، فمن كانت هجرته إلى الله ورسوله فهجرته إلى الله ورسوله ومن كانت هجرته إلى دنيا يصيبها أو امرأة ينكحها، فهجرته إلى ما هاجر إليه»",
                                    OnPublisher = "عن عمر، رواه الشيخان",
                                    CategoryId = 3,
                                },
                                new Hadit
                                {
                                    Content = "«إنما الطاعة في المعروف»",
                                    OnPublisher = "عن علِيّ رضي الله عنه، رواه الشيخان",
                                    CategoryId = 3,
                                },
                                new Hadit
                                {
                                    Content = "«إن مما أدرك الناس من كلام النبوة الأولى: إذا لم تستح فاصنع ما شئت»",
                                    OnPublisher = "عن ابن مسعود، أخرجه البخاري",
                                    CategoryId = 3,
                                },
                                new Hadit
                                {
                                    Content = "«إن من الشعر لحكمة»",
                                    OnPublisher = "عن أُبيّ بن كعب، أخرجه البخاري",
                                    CategoryId = 3,
                                },
                                new Hadit
                                {
                                    Content = "«المؤمن للمؤمن كالبنيان يَشُدُّ بعضه بعضا»",
                                    OnPublisher = "عن أبي موسى، رواه البخاري",
                                    CategoryId = 3,
                                },
                                new Hadit
                                {
                                    Content = "«إني لأقوم في الصلاة أريد أن أطوّل فيها فأسمع بكاء الصبيّ فأتجوّز في صلاتي كراهية أن أشقّ على أمه»",
                                    OnPublisher = "عن قتادة، رواه البخاري",
                                    CategoryId = 3,
                                },
                                new Hadit
                                {
                                    Content = "«إياكم والحسد، فإن الحسد يأكل الحسنات كما تأكل النار الحطب»",
                                    OnPublisher = "عن أبي هريرة، أخرجه أبو داود، ولابن ماجه من حديث أنس مثله",
                                    CategoryId = 3,
                                },
                                new Hadit
                                {
                                    Content = "«الإيمان أن تؤمن بالله وملائكته وكتابه وبلقائه وبرسله، وتؤمن بالبعث الآخر»",
                                    OnPublisher = "عن أبي هريرة، رواه الشيخان",
                                    CategoryId = 3,
                                },
                                new Hadit
                                {
                                    Content = "«الإيمان بضع وستون شُعبة، والحياء شُعبة من الإيمان»",
                                    OnPublisher = "عن أبي هريرة، رواه البخاري",
                                    CategoryId = 3,
                                },
                                new Hadit
                                {
                                    Content = "«بني الإسلام على خمس: شهادة أن لا إله إلا الله وأن محمدا رسول الله، وإقامَ الصلاة، وإيتاءَ الزكاة، والحج، وصوم رمضان»",
                                    OnPublisher = "عن ابن عمر، رواه البخاري",
                                    CategoryId = 3,
                                },


                            };
                            context.Hadites.AddRange(Hadites);
                        }

                        context.SaveChanges();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
            }
        }

    }
}
