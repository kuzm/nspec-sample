using NSpec;
using Shouldly;

namespace NSpecSample
{
    public class describe_my_first_nspec : nspec
    {
        void they_are_loud_and_emphatic()
        {
            string sound = null; 
            string ending = null;

            before = () => 
                ending = "!!!";
            
            act = () => 
                sound = sound.ToUpper() + ending;

            context["given bam"] = () => 
            {
                before = () => 
                    sound = "bam";
                it["should be BAM!!!"] = () => 
                    sound.ShouldBe("BAM!!!");
            };

            context["given whack", tags: "whack"] = () => 
            {
                before = () => 
                    sound = "whack";
                it["should be WHACK!!!"] = () => 
                    sound.ShouldBe("WHACK!!!");
            };
        }

        [Tag("boom")]
        void it_should_be_boom()
        {
        }
    }
}