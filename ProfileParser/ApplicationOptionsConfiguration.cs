using ProfileParser.Abstraction.Options;
using ProfileParser.Options;
using ProfileParser.Utils;

namespace ProfileParser;

public class ApplicationOptionsConfiguration
{
    public static ParsingOptions GetDefaultInstagramParsingOptions()
    {
        return new InstagramParsingOptions()
        {
            About = "h1._ap3a._aaco._aacu._aacx._aad6._aade",
            FollowerPageLink =
                "a.x1i10hfl.xjbqb8w.x6umtig.x1b1mbwd.xaqea5y.xav7gou.x9f619.x1ypdohk.xt0psk2.xe8uvvx.xdj266r.x11i5rnm.xat24cr.x1mh8g0r.xexx8yu.x4uap5.x18d9i69.xkhd6sd.x16tdsg8.x1hl2dhg.xggy1nq.x1a2a7pz.notranslate._a6hd",
            FollowerBlock = "div.x1dm5mii.x16mil14.xiojian.x1yutycm.x1lliihq.x193iq5w.xh8yej3",
            FollowersBlock = "div.x7r02ix.xf1ldfh.x131esax.xdajt7p.xxfnqb6.xb88tzc.xw2csxc.x1odjw0f.x5fp0pe",
            FollowersSection = "ul.x78zum5.x1q0g3np.xieb3on",
            NickNameBlock =
                "h2.x1lliihq.x1plvlek.xryxfnj.x1n2onr6.x193iq5w.xeuugli.x1fj9vlw.x13faqbe.x1vvkbs.x1s928wv.xhkezso.x1gmr53x.x1cpjm7i.x1fgarty.x1943h6x.x1i0vuye.x1ms8i2q.xo1l8bm.x5n08af.x10wh9bi.x1wdrske.x8viiok.x18hxmgj",
            ToAccount = SelectorConverter.ConvertToSelector("a",
                "x1i10hfl xjbqb8w x6umtig x1b1mbwd xaqea5y xav7gou x9f619 x1ypdohk xt0psk2 xe8uvvx xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x16tdsg8 x1hl2dhg xggy1nq x1a2a7pz _a6hd"),
            CloseLogInModalButton = "button._a9--._ap36._a9_1",
            SideBar = "div.x1iyjqo2.xh8yej3",
            OverallInfo = "ul.x78zum5.x1q0g3np.xieb3on",
            UserInfoSection =
                "section.x1qjc9v5.x972fbf.xcfux6l.x1qhh985.xm0m39n.x9f619.x5n08af.x78zum5.xdt5ytf.xs83m0k.xk390pu.xdj266r.x11i5rnm.xat24cr.x1mh8g0r.xeuugli.xexx8yu.x4uap5.x18d9i69.xkhd6sd.x1n2onr6.x11njtxf.xg1prrt.x1quol0o.x139hhg0.x1qgnrqa",
            UserName =
                "h2.x1lliihq.x1plvlek.xryxfnj.x1n2onr6.x193iq5w.xeuugli.x1fj9vlw.x13faqbe.x1vvkbs.x1s928wv.xhkezso.x1gmr53x.x1cpjm7i.x1fgarty.x1943h6x.x1i0vuye.x1ms8i2q.xo1l8bm.x5n08af.x10wh9bi.x1wdrske.x8viiok.x18hxmgj",
            Home = SelectorConverter.ConvertToSelector("a",
                "x1i10hfl xjbqb8w x6umtig x1b1mbwd xaqea5y xav7gou x9f619 x1ypdohk xt0psk2 xe8uvvx xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x16tdsg8 x1hl2dhg xggy1nq x1a2a7pz _a6hd"),
            SecondNameBlock =
                "span.x1lliihq.x1plvlek.xryxfnj.x1n2onr6.x193iq5w.xeuugli.x1fj9vlw.x13faqbe.x1vvkbs.x1s928wv.xhkezso.x1gmr53x.x1cpjm7i.x1fgarty.x1943h6x.x1i0vuye.xvs91rp.x1s688f.x5n08af.x10wh9bi.x1wdrske.x8viiok.x18hxmgj",
            AccountAbout = "div._ap3a._aaco._aacu._aacy._aad6._aade",
            BioBlock = "h1._ap3a._aaco._aacu._aacx._aad6._aade",
            WebSite = "span.x1lliihq.x193iq5w.x6ikm8r.x10wlt62.xlyipyv.xuxw1ft",
            SettingsWrapper = ".xl5mz7h.xhuyl8g",
            SettingsButton =
                ".x1i10hfl.xjbqb8w.x6umtig.x1b1mbwd.xaqea5y.xav7gou.x9f619.x1ypdohk.xt0psk2.xe8uvvx.xdj266r.x11i5rnm.xat24cr.x1mh8g0r.xexx8yu.x4uap5.x18d9i69.xkhd6sd.x16tdsg8.x1hl2dhg.xggy1nq.x1a2a7pz._a6hd",
            LogoutBlock = ".xu96u03.xm80bdy.x10l6tqk.x13vifvy .x1y1aw1k.x1sxyh0.xwib8y2.xurb0ha",
            LogoutButton =
                ".x1i10hfl.x1qjc9v5.xjbqb8w.xjqpnuy.xa49m3k.xqeqjp1.x2hbi6w.x13fuv20.xu3j5b3.x1q0q8m5.x26u7qi.x972fbf.xcfux6l.x1qhh985.xm0m39n.x9f619.x1ypdohk.xdl72j9.x2lah0s.xe8uvvx.xdj266r.x11i5rnm.xat24cr.x1mh8g0r.x2lwn1j.xeuugli.xexx8yu.x4uap5.x18d9i69.xkhd6sd.x1n2onr6.x16tdsg8.x1hl2dhg.xggy1nq.x1ja2u2z.x1t137rt.x1q0g3np.x87ps6o.x1lku1pv.x1a2a7pz.x1dm5mii.x16mil14.xiojian.x1yutycm.x1lliihq.x193iq5w.xh8yej3",
            PrivateAccountBlock = "._aady._aa_s ._aa_u"
        };
    }

    public static AuthorizationOptions GetInstagramAuthorizationOptions()
    {
        return new AuthorizationOptions()
        {
            ErrorSection = "div._ab2z",
            LoginButton = "button._acan._acap._acas._aj1-._ap30",
            LoginFieldIdentifier = "input._aa4b._add6._ac4d._ap35[type='text']",
            PasswordFieldIdentifier = "input._aa4b._add6._ac4d._ap35[type='password']",
            LogInSuccessElement =
                "div.x1xgvd2v.x1o5hw5a.xaeubzz.x1cy8zhl.xvbhtw8.x9f619.x78zum5.xdt5ytf.x1gvbg2u.x1y1aw1k.xn6708d.xx6bls6.x1ye3gou"
        };
    }
}