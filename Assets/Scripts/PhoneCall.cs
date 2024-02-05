using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneCall : MonoBehaviour
{
    public void OnClickCamera() { }

    public void OnClickDrop()
    {
        Destroy(gameObject);
        if (Utils.GetInstance().hasGetGuideCall == false)
        {
            // 没讲完就挂电话
            var guideNode = transform.parent.Find("Guide");
            guideNode.GetComponent<Guide>().ShowGuidePhoneCall();
        }
        else {
            var guideNode = transform.parent.Find("Guide");
            guideNode.GetComponent<Guide>().ShowMesageNotifi();
            Utils.GetInstance().isStudioLock = false;
        }
    }

    public void OnClickMute() { }


    public void OnGuideChoose1A()
    {
        UIManger.GetInstance().showChatBox(transform, "player", "Are you the Noah, like the movie star Noah?", () =>
        {
            UIManger.GetInstance().showChatBox(transform, "Noah", "Guilty as charged! The one and only. Though yesterday, I was more like \"Noah, the accidental tornado in a cafe.\" Though I am glad you've heard of me. I am not quite a \"star\", I mean, not yet, not in Hollywood. Anyway, I am not here to talk about myself. What can I do to make things right for you?", () =>
            {
                var list = new List<ChooseInfo> {
                        new("Nothing you can do",()=>{
                            OnGuideChoose2A();
                        }),
                        new("What's your plan?",() => {
                            OnGuideChoose2B();
                        }) ,
                   };
                UIManger.GetInstance().showChooseBox(transform, list);
            });
        });
    }

    public void OnGuideChoose1B()
    {
        UIManger.GetInstance().showChatBox(transform, "player", "What exactly happened at the cafe, though?", () =>
        {
            UIManger.GetInstance().showChatBox(transform, "Noah", "So, long story short, my friend and I had this intense, well, let's call it a \"creative disagreement\" about the values of pursuing our acting dreams. She is a true star, I would give her that. It spiraled into a chaotic debate, and we accidentally turned your cafe into a set for an avant-garde drama. Again, I am so sorry, what can I do to make things right for you?", () =>
            {
                var list = new List<ChooseInfo> {
                        new("Nothing you can do",()=>{
                            OnGuideChoose2A();
                        }),
                        new("What's your plan?",() => {
                            OnGuideChoose2B();
                        }) ,
                   };
                UIManger.GetInstance().showChooseBox(transform, list);
            });
        });
    }

    public void OnGuideChoose1C()
    {
        UIManger.GetInstance().showChatBox(transform, "player", "I'm still wrapping my head around everything. Any ideas on how to make amends?", () =>
        {
            UIManger.GetInstance().showChatBox(transform, "Noah", "I'm really keen on making things right. How about this: I know some folks in the industry, and I also know they are looking for someone passionate and talented. So I'd love to do this in Hollywood style. A movie audition. What do you think?", () =>
            {
                var list = new List<ChooseInfo> {
                        new("great",()=>{
                            OnGuideChoose3A();
                        }),
                        new("I am not sure",() => {
                            OnGuideChoose3B();
                        }) ,
                   };
                UIManger.GetInstance().showChooseBox(transform, list);
            });
        });
    }


    public void OnGuideChoose2A()
    {
        UIManger.GetInstance().showChatBox(transform, "player", "Honestly, Noah, I appreciate the apology, but I'm not sure what can be done.", () =>
        {
            UIManger.GetInstance().showChatBox(transform, "Noah", "I get it. But what if I could help turn this chapter around for you? I noticed you were into some actress's biography when we met. How about I set you up with a new movie audition? My treat, as a way to make amends.", () =>
            {
                var list = new List<ChooseInfo> {
                        new("great",()=>{
                            OnGuideChoose3A();
                        }),
                        new("I am not sure",() => {
                            OnGuideChoose3B();
                        }) ,
                   };
                UIManger.GetInstance().showChooseBox(transform, list);
            });
        });
    }


    public void OnGuideChoose2B()
    {
        UIManger.GetInstance().showChatBox(transform, "player", "Well, Noah, it's a bit of a mess, to be honest. What's your plan?", () =>
        {
            UIManger.GetInstance().showChatBox(transform, "Noah", "Sometimes sorry isn't enough. I saw a spark in your eyes when you were talking about \"movie star\". Let's make this right and give you a chance to shine. I am talking about a movie audition for you. What do you say?", () =>
            {
                var list = new List<ChooseInfo> {
                        new("great",()=>{
                            OnGuideChoose3A();
                        }),
                        new("I am not sure",() => {
                            OnGuideChoose3B();
                        }) ,
                   };
                UIManger.GetInstance().showChooseBox(transform, list);
            });
        });
    }


    public void OnGuideChoose3A()
    {
        UIManger.GetInstance().showChatBox(transform, "player", "Well, that's definitely unexpected, but I'm willing to give it a shot.", () =>
        {
            UIManger.GetInstance().showChatBox(transform, "Noah", "Fantastic! I'll get things moving and keep you in the loop. Here's to turning yesterday's chaos into the beginning of something great! How about we get you into the studio ASAP? Strike while the iron's hot, right? I'll send you all the details. Get ready for lights, camera, and your Hollywood moment!", () =>
            {
                //finish
                Utils.GetInstance().hasGetGuideCall = true;
                this.OnClickDrop();
            });
        });
    }


    public void OnGuideChoose3B()
    {
        UIManger.GetInstance().showChatBox(transform, "player", "I appreciate the offer, Noah, but I'm not sure about the whole Hollywood audition thing.", () =>
        {
            UIManger.GetInstance().showChatBox(transform, "Noah", "Totally get it. It's a bit out of left field. But think of it as an opportunity, a chance to showcase your talent. Plus, it's my way of saying sorry in a big way. What's holding you back?", () =>
            {
                UIManger.GetInstance().showChatBox(transform, "player", "It's just unexpected, you know? I never thought something like this would come from what happened at the cafe.", () =>
                {
                    UIManger.GetInstance().showChatBox(transform, "Noah", "Life is full of unexpected twists, right? This could be your chance to turn a chaotic day into something amazing. Take your time to think about it. No pressure.", () =>
                    {
                        UIManger.GetInstance().showChatBox(transform, "player", "Alright, Noah. I'll think about it. It's definitely a unique offer.", () =>
                        {
                            UIManger.GetInstance().showChatBox(transform, "Noah", "Great! I'll be here whenever you're ready. Let's turn the unexpected into something extraordinary. How about we get you into the studio ASAP? Strike while the iron's hot, right? I'll send you all the details. Get ready for lights, camera, and your Hollywood moment!", () =>
                            {
                                // finish
                                Utils.GetInstance().hasGetGuideCall = true;
                                this.OnClickDrop();
                            });

                        });
                    });
                });
            });
        });
    }


    public void Start()
    {
        if (Utils.IsGuide())
        {
            UIManger.GetInstance().showChatBox(transform, "Noah", "Hey, it's Noah. I hope you're doing okay after yesterday. So, about the cafe debacle, it's been eating at me. I'm really sorry about what went down and especially about your job. We didn't mean to make a mess back there.", () =>
               {
                   var list = new List<ChooseInfo> {
                        new("Are you 'Noah the movie star'?",()=>{
                            OnGuideChoose1A();
                        }),
                        new("Ask about the mess",() => {
                            OnGuideChoose1B();
                        }) ,
                        new("Ask for amends",() => {
                            OnGuideChoose1C();
                        }),
                   };
                   UIManger.GetInstance().showChooseBox(transform, list);
               });
        }

    }
}
