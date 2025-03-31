var synowebapi = (function () {
  "use strict";
  function t(t, e) {
    for (var r = 0; r < e.length; r++) {
      var n = e[r];
      (n.enumerable = n.enumerable || !1),
        (n.configurable = !0),
        "value" in n && (n.writable = !0),
        Object.defineProperty(t, n.key, n);
    }
  }
  function e() {
    return (e =
      Object.assign ||
      function (t) {
        for (var e = 1; e < arguments.length; e++) {
          var r = arguments[e];
          for (var n in r)
            Object.prototype.hasOwnProperty.call(r, n) && (t[n] = r[n]);
        }
        return t;
      }).apply(this, arguments);
  }
  function r(t, e) {
    (t.prototype = Object.create(e.prototype)),
      (t.prototype.constructor = t),
      n(t, e);
  }
  function n(t, e) {
    return (n =
      Object.setPrototypeOf ||
      function (t, e) {
        return (t.__proto__ = e), t;
      })(t, e);
  }
  var i = (function () {
    function t(t) {
      void 0 === t && (t = Object.create(null));
      var e = t,
        r = e.baseURL,
        n = e.synotoken,
        i = e.isSecure,
        o = e.legacyMode,
        s = void 0 === o || o;
      (this.baseURL = r || ""),
        (this.synoToken = n || ""),
        (this.forceSecure = i),
        (this.legacyMode = s),
        (this.credential = null);
    }
    var e = t.prototype;
    return (
      (e.getBaseURL = function () {
        return this.baseURL;
      }),
      (e.setBaseURL = function (t) {
        this.baseURL = t;
      }),
      (e.getSynoToken = function () {
        return this.synoToken;
      }),
      (e.setSynoToken = function (t) {
        this.synoToken = t;
      }),
      (e._isSecure = function () {
        return this.getBaseURL().startsWith("https:");
      }),
      (e.isSecure = function () {
        var t = this.forceSecure;
        return "boolean" == typeof t ? t : this._isSecure();
      }),
      (e.setLegacyMode = function (t) {
        this.legacyMode = t;
      }),
      (e.isLegacyMode = function () {
        return this.legacyMode;
      }),
      (e.setCredential = function (t) {
        this.credential = t;
      }),
      (e.getCredential = function () {
        return this.credential;
      }),
      (e.getRequestHeaders = function () {
        var t = {};
        return (
          this.synoToken && (t["X-SYNO-TOKEN"] = this.synoToken),
          this.credential &&
            Object.assign(t, this.credential.GetRequestHeaders()),
          t
        );
      }),
      t
    );
  })();
  function o(t, e) {
    return Object.prototype.hasOwnProperty.call(t, e);
  }
  function s(t) {
    return "[object Error]" == Object.prototype.toString.call(t);
  }
  function a(t) {
    var e = [];
    for (var r in t)
      o(t, r) && e.push(encodeURIComponent(r) + "=" + encodeURIComponent(t[r]));
    return e.join("&");
  }
  function c(t) {
    return null == t;
  }
  var u = (function () {
      function t(t, e, r) {
        c(t) ||
          ("number" == typeof t
            ? this.fromNumber(t, e, r)
            : c(e) && "string" != typeof t
            ? this.fromString(t, 256)
            : this.fromString(t, e));
      }
      function e() {
        return new t(null);
      }
      function r(t, e, r, n, i, o) {
        for (; --o >= 0; ) {
          var s = e * this[t++] + r[n] + i;
          (i = Math.floor(s / 67108864)), (r[n++] = 67108863 & s);
        }
        return i;
      }
      function n(t, e, r, n, i, o) {
        for (var s = 32767 & e, a = e >> 15; --o >= 0; ) {
          var c = 32767 & this[t],
            u = this[t++] >> 15,
            h = a * c + u * s;
          (i =
            ((c = s * c + ((32767 & h) << 15) + r[n] + (1073741823 & i)) >>>
              30) +
            (h >>> 15) +
            a * u +
            (i >>> 30)),
            (r[n++] = 1073741823 & c);
        }
        return i;
      }
      function i(t, e, r, n, i, o) {
        for (var s = 16383 & e, a = e >> 14; --o >= 0; ) {
          var c = 16383 & this[t],
            u = this[t++] >> 14,
            h = a * c + u * s;
          (i =
            ((c = s * c + ((16383 & h) << 14) + r[n] + i) >> 28) +
            (h >> 14) +
            a * u),
            (r[n++] = 268435455 & c);
        }
        return i;
      }
      var o,
        s =
          ("Microsoft Internet Explorer" ===
          (o = "undefined" != typeof navigator && navigator.appName)
            ? ((t.prototype.am = n), (s = 30))
            : "Netscape" === o
            ? ((t.prototype.am = r), (s = 26))
            : ((t.prototype.am = i), (s = 28)),
          s);
      (t.prototype.DB = s),
        (t.prototype.DM = (1 << s) - 1),
        (t.prototype.DV = 1 << s);
      (t.prototype.FV = Math.pow(2, 52)),
        (t.prototype.F1 = 52 - s),
        (t.prototype.F2 = 2 * s - 52);
      var a,
        u,
        h = [];
      for (a = "0".charCodeAt(0), u = 0; u <= 9; ++u) h[a++] = u;
      for (a = "a".charCodeAt(0), u = 10; u < 36; ++u) h[a++] = u;
      for (a = "A".charCodeAt(0), u = 10; u < 36; ++u) h[a++] = u;
      function f(t) {
        return "0123456789abcdefghijklmnopqrstuvwxyz".charAt(t);
      }
      function p(t, e) {
        var r = h[t.charCodeAt(e)];
        return c(r) ? -1 : r;
      }
      function l(t) {
        var r = e();
        return r.fromInt(t), r;
      }
      function d(t) {
        var e,
          r = 1;
        return (
          0 != (e = t >>> 16) && ((t = e), (r += 16)),
          0 != (e = t >> 8) && ((t = e), (r += 8)),
          0 != (e = t >> 4) && ((t = e), (r += 4)),
          0 != (e = t >> 2) && ((t = e), (r += 2)),
          0 != (e = t >> 1) && ((t = e), (r += 1)),
          r
        );
      }
      function v(t) {
        this.m = t;
      }
      function m(t) {
        (this.m = t),
          (this.mp = t.invDigit()),
          (this.mpl = 32767 & this.mp),
          (this.mph = this.mp >> 15),
          (this.um = (1 << (t.DB - 15)) - 1),
          (this.mt2 = 2 * t.t);
      }
      return (
        (v.prototype.convert = function (t) {
          return t.s < 0 || t.compareTo(this.m) >= 0 ? t.mod(this.m) : t;
        }),
        (v.prototype.revert = function (t) {
          return t;
        }),
        (v.prototype.reduce = function (t) {
          t.divRemTo(this.m, null, t);
        }),
        (v.prototype.mulTo = function (t, e, r) {
          t.multiplyTo(e, r), this.reduce(r);
        }),
        (v.prototype.sqrTo = function (t, e) {
          t.squareTo(e), this.reduce(e);
        }),
        (m.prototype.convert = function (r) {
          var n = e();
          return (
            r.abs().dlShiftTo(this.m.t, n),
            n.divRemTo(this.m, null, n),
            r.s < 0 && n.compareTo(t.ZERO) > 0 && this.m.subTo(n, n),
            n
          );
        }),
        (m.prototype.revert = function (t) {
          var r = e();
          return t.copyTo(r), this.reduce(r), r;
        }),
        (m.prototype.reduce = function (t) {
          for (; t.t <= this.mt2; ) t[t.t++] = 0;
          for (var e = 0; e < this.m.t; ++e) {
            var r = 32767 & t[e],
              n =
                (r * this.mpl +
                  (((r * this.mph + (t[e] >> 15) * this.mpl) & this.um) <<
                    15)) &
                t.DM;
            for (
              t[(r = e + this.m.t)] += this.m.am(0, n, t, e, 0, this.m.t);
              t[r] >= t.DV;

            )
              (t[r] -= t.DV), t[++r]++;
          }
          t.clamp(),
            t.drShiftTo(this.m.t, t),
            t.compareTo(this.m) >= 0 && t.subTo(this.m, t);
        }),
        (m.prototype.mulTo = function (t, e, r) {
          t.multiplyTo(e, r), this.reduce(r);
        }),
        (m.prototype.sqrTo = function (t, e) {
          t.squareTo(e), this.reduce(e);
        }),
        (t.prototype.copyTo = function (t) {
          for (var e = this.t - 1; e >= 0; --e) t[e] = this[e];
          (t.t = this.t), (t.s = this.s);
        }),
        (t.prototype.fromInt = function (t) {
          (this.t = 1),
            (this.s = t < 0 ? -1 : 0),
            t > 0
              ? (this[0] = t)
              : t < -1
              ? (this[0] = t + this.DV)
              : (this.t = 0);
        }),
        (t.prototype.fromString = function (e, r) {
          var n;
          if (16 == r) n = 4;
          else if (8 == r) n = 3;
          else if (256 == r) n = 8;
          else if (2 == r) n = 1;
          else if (32 == r) n = 5;
          else {
            if (4 != r) return void this.fromRadix(e, r);
            n = 2;
          }
          (this.t = 0), (this.s = 0);
          for (var i = e.length, o = !1, s = 0; --i >= 0; ) {
            var a = 8 == n ? 255 & e[i] : p(e, i);
            a < 0
              ? "-" == e.charAt(i) && (o = !0)
              : ((o = !1),
                0 === s
                  ? (this[this.t++] = a)
                  : s + n > this.DB
                  ? ((this[this.t - 1] |=
                      (a & ((1 << (this.DB - s)) - 1)) << s),
                    (this[this.t++] = a >> (this.DB - s)))
                  : (this[this.t - 1] |= a << s),
                (s += n) >= this.DB && (s -= this.DB));
          }
          8 == n &&
            0 != (128 & e[0]) &&
            ((this.s = -1),
            s > 0 && (this[this.t - 1] |= ((1 << (this.DB - s)) - 1) << s)),
            this.clamp(),
            o && t.ZERO.subTo(this, this);
        }),
        (t.prototype.clamp = function () {
          for (var t = this.s & this.DM; this.t > 0 && this[this.t - 1] == t; )
            --this.t;
        }),
        (t.prototype.dlShiftTo = function (t, e) {
          var r;
          for (r = this.t - 1; r >= 0; --r) e[r + t] = this[r];
          for (r = t - 1; r >= 0; --r) e[r] = 0;
          (e.t = this.t + t), (e.s = this.s);
        }),
        (t.prototype.drShiftTo = function (t, e) {
          for (var r = t; r < this.t; ++r) e[r - t] = this[r];
          (e.t = Math.max(this.t - t, 0)), (e.s = this.s);
        }),
        (t.prototype.lShiftTo = function (t, e) {
          var r,
            n = t % this.DB,
            i = this.DB - n,
            o = (1 << i) - 1,
            s = Math.floor(t / this.DB),
            a = (this.s << n) & this.DM;
          for (r = this.t - 1; r >= 0; --r)
            (e[r + s + 1] = (this[r] >> i) | a), (a = (this[r] & o) << n);
          for (r = s - 1; r >= 0; --r) e[r] = 0;
          (e[s] = a), (e.t = this.t + s + 1), (e.s = this.s), e.clamp();
        }),
        (t.prototype.rShiftTo = function (t, e) {
          e.s = this.s;
          var r = Math.floor(t / this.DB);
          if (r >= this.t) e.t = 0;
          else {
            var n = t % this.DB,
              i = this.DB - n,
              o = (1 << n) - 1;
            e[0] = this[r] >> n;
            for (var s = r + 1; s < this.t; ++s)
              (e[s - r - 1] |= (this[s] & o) << i), (e[s - r] = this[s] >> n);
            n > 0 && (e[this.t - r - 1] |= (this.s & o) << i),
              (e.t = this.t - r),
              e.clamp();
          }
        }),
        (t.prototype.subTo = function (t, e) {
          for (var r = 0, n = 0, i = Math.min(t.t, this.t); r < i; )
            (n += this[r] - t[r]), (e[r++] = n & this.DM), (n >>= this.DB);
          if (t.t < this.t) {
            for (n -= t.s; r < this.t; )
              (n += this[r]), (e[r++] = n & this.DM), (n >>= this.DB);
            n += this.s;
          } else {
            for (n += this.s; r < t.t; )
              (n -= t[r]), (e[r++] = n & this.DM), (n >>= this.DB);
            n -= t.s;
          }
          (e.s = n < 0 ? -1 : 0),
            n < -1 ? (e[r++] = this.DV + n) : n > 0 && (e[r++] = n),
            (e.t = r),
            e.clamp();
        }),
        (t.prototype.multiplyTo = function (e, r) {
          var n = this.abs(),
            i = e.abs(),
            o = n.t;
          for (r.t = o + i.t; --o >= 0; ) r[o] = 0;
          for (o = 0; o < i.t; ++o) r[o + n.t] = n.am(0, i[o], r, o, 0, n.t);
          (r.s = 0), r.clamp(), this.s != e.s && t.ZERO.subTo(r, r);
        }),
        (t.prototype.squareTo = function (t) {
          var e,
            r = this.abs();
          for (e = t.t = 2 * r.t; --e >= 0; ) t[e] = 0;
          for (e = 0; e < r.t - 1; ++e) {
            var n = r.am(e, r[e], t, 2 * e, 0, 1);
            (t[e + r.t] += r.am(
              e + 1,
              2 * r[e],
              t,
              2 * e + 1,
              n,
              r.t - e - 1
            )) >= r.DV && ((t[e + r.t] -= r.DV), (t[e + r.t + 1] = 1));
          }
          t.t > 0 && (t[t.t - 1] += r.am(e, r[e], t, 2 * e, 0, 1)),
            (t.s = 0),
            t.clamp();
        }),
        (t.prototype.divRemTo = function (r, n, i) {
          var o = r.abs();
          if (!(o.t <= 0)) {
            var s = this.abs();
            if (s.t < o.t)
              return c(n) || n.fromInt(0), void (c(i) || this.copyTo(i));
            c(i) && (i = e());
            var a = e(),
              u = this.s,
              h = r.s,
              f = this.DB - d(o[o.t - 1]);
            f > 0
              ? (o.lShiftTo(f, a), s.lShiftTo(f, i))
              : (o.copyTo(a), s.copyTo(i));
            var p = a.t,
              l = a[p - 1];
            if (0 !== l) {
              var v = l * (1 << this.F1) + (p > 1 ? a[p - 2] >> this.F2 : 0),
                m = this.FV / v,
                y = (1 << this.F1) / v,
                g = 1 << this.F2,
                _ = i.t,
                b = _ - p,
                w = c(n) ? e() : n;
              for (
                a.dlShiftTo(b, w),
                  i.compareTo(w) >= 0 && ((i[i.t++] = 1), i.subTo(w, i)),
                  t.ONE.dlShiftTo(p, w),
                  w.subTo(a, a);
                a.t < p;

              )
                a[a.t++] = 0;
              for (; --b >= 0; ) {
                var S =
                  i[--_] == l
                    ? this.DM
                    : Math.floor(i[_] * m + (i[_ - 1] + g) * y);
                if ((i[_] += a.am(0, S, i, b, 0, p)) < S)
                  for (a.dlShiftTo(b, w), i.subTo(w, i); i[_] < --S; )
                    i.subTo(w, i);
              }
              c(n) || (i.drShiftTo(p, n), u != h && t.ZERO.subTo(n, n)),
                (i.t = p),
                i.clamp(),
                f > 0 && i.rShiftTo(f, i),
                u < 0 && t.ZERO.subTo(i, i);
            }
          }
        }),
        (t.prototype.invDigit = function () {
          if (this.t < 1) return 0;
          var t = this[0];
          if (0 == (1 & t)) return 0;
          var e = 3 & t;
          return (e =
            ((e =
              ((e =
                ((e = (e * (2 - (15 & t) * e)) & 15) * (2 - (255 & t) * e)) &
                255) *
                (2 - (((65535 & t) * e) & 65535))) &
              65535) *
              (2 - ((t * e) % this.DV))) %
            this.DV) > 0
            ? this.DV - e
            : -e;
        }),
        (t.prototype.isEven = function () {
          return 0 === (this.t > 0 ? 1 & this[0] : this.s);
        }),
        (t.prototype.exp = function (r, n) {
          if (r > 4294967295 || r < 1) return t.ONE;
          var i = e(),
            o = e(),
            s = n.convert(this),
            a = d(r) - 1;
          for (s.copyTo(i); --a >= 0; )
            if ((n.sqrTo(i, o), (r & (1 << a)) > 0)) n.mulTo(o, s, i);
            else {
              var c = i;
              (i = o), (o = c);
            }
          return n.revert(i);
        }),
        (t.prototype.toString = function (t) {
          if (this.s < 0) return "-" + this.negate().toString(t);
          var e;
          if (16 == t) e = 4;
          else if (8 == t) e = 3;
          else if (2 == t) e = 1;
          else if (32 == t) e = 5;
          else {
            if (4 != t) return this.toRadix(t);
            e = 2;
          }
          var r,
            n = (1 << e) - 1,
            i = !1,
            o = "",
            s = this.t,
            a = this.DB - ((s * this.DB) % e);
          if (s-- > 0)
            for (
              a < this.DB && (r = this[s] >> a) > 0 && ((i = !0), (o = f(r)));
              s >= 0;

            )
              a < e
                ? ((r = (this[s] & ((1 << a) - 1)) << (e - a)),
                  (r |= this[--s] >> (a += this.DB - e)))
                : ((r = (this[s] >> (a -= e)) & n),
                  a <= 0 && ((a += this.DB), --s)),
                r > 0 && (i = !0),
                i && (o += f(r));
          return i ? o : "0";
        }),
        (t.prototype.negate = function () {
          var r = e();
          return t.ZERO.subTo(this, r), r;
        }),
        (t.prototype.abs = function () {
          return this.s < 0 ? this.negate() : this;
        }),
        (t.prototype.compareTo = function (t) {
          var e = this.s - t.s;
          if (0 !== e) return e;
          var r = this.t;
          if (0 !== (e = r - t.t)) return e;
          for (; --r >= 0; ) if (0 != (e = this[r] - t[r])) return e;
          return 0;
        }),
        (t.prototype.bitLength = function () {
          return this.t <= 0
            ? 0
            : this.DB * (this.t - 1) + d(this[this.t - 1] ^ (this.s & this.DM));
        }),
        (t.prototype.mod = function (r) {
          var n = e();
          return (
            this.abs().divRemTo(r, null, n),
            this.s < 0 && n.compareTo(t.ZERO) > 0 && r.subTo(n, n),
            n
          );
        }),
        (t.prototype.modPowInt = function (t, e) {
          var r;
          return (
            (r = t < 256 || e.isEven() ? new v(e) : new m(e)), this.exp(t, r)
          );
        }),
        (t.ZERO = l(0)),
        (t.ONE = l(1)),
        t
      );
    })(),
    h = (function () {
      function t() {
        (this.i = 0), (this.j = 0), (this.S = []);
      }
      (t.prototype.init = function (t) {
        var e, r, n;
        for (e = 0; e < 256; ++e) this.S[e] = e;
        for (r = 0, e = 0; e < 256; ++e)
          (r = (r + this.S[e] + t[e % t.length]) & 255),
            (n = this.S[e]),
            (this.S[e] = this.S[r]),
            (this.S[r] = n);
        (this.i = 0), (this.j = 0);
      }),
        (t.prototype.next = function () {
          var t;
          return (
            (this.i = (this.i + 1) & 255),
            (this.j = (this.j + this.S[this.i]) & 255),
            (t = this.S[this.i]),
            (this.S[this.i] = this.S[this.j]),
            (this.S[this.j] = t),
            this.S[(t + this.S[this.i]) & 255]
          );
        });
      var e, r, n;
      function i() {
        var t;
        (t = new Date().getTime()),
          (r[n++] ^= 255 & t),
          (r[n++] ^= (t >> 8) & 255),
          (r[n++] ^= (t >> 16) & 255),
          (r[n++] ^= (t >> 24) & 255),
          n >= 256 && (n -= 256);
      }
      if (!r) {
        var o;
        for (r = [], n = 0; n < 256; )
          (o = Math.floor(65536 * Math.random())),
            (r[n++] = o >>> 8),
            (r[n++] = 255 & o);
        (n = 0), i();
      }
      function s() {
        if (!e) {
          for (i(), (e = new t()).init(r), n = 0; n < r.length; ++n) r[n] = 0;
          n = 0;
        }
        return e.next();
      }
      function a() {}
      return (
        (a.prototype.nextBytes = function (t) {
          var e;
          for (e = 0; e < t.length; ++e) t[e] = s();
        }),
        (a.rng_seed_time = i),
        a
      );
    })();
  function f(t) {
    return null == t;
  }
  var p = (function () {
    function t() {
      (this.n = null),
        (this.e = 0),
        (this.d = null),
        (this.p = null),
        (this.q = null),
        (this.dmp1 = null),
        (this.dmq1 = null),
        (this.coeff = null);
    }
    return (
      (t.prototype.doPublic = function (t) {
        return t.modPowInt(this.e, this.n);
      }),
      (t.prototype.setPublic = function (t, e) {
        !f(t) &&
          !f(e) &&
          t.length > 0 &&
          e.length > 0 &&
          ((this.n = new u(t, 16)), (this.e = parseInt(e, 16)));
      }),
      (t.prototype.encrypt = function (t) {
        var e = (function (t, e) {
          if (e < t.length + 11) return null;
          for (var r = [], n = t.length - 1; n >= 0 && e > 0; ) {
            var i = t.charCodeAt(n--);
            i < 128
              ? (r[--e] = i)
              : i > 127 && i < 2048
              ? ((r[--e] = (63 & i) | 128), (r[--e] = (i >> 6) | 192))
              : ((r[--e] = (63 & i) | 128),
                (r[--e] = ((i >> 6) & 63) | 128),
                (r[--e] = (i >> 12) | 224));
          }
          r[--e] = 0;
          for (var o = new h(), s = []; e > 2; ) {
            for (s[0] = 0; 0 === s[0]; ) o.nextBytes(s);
            r[--e] = s[0];
          }
          return (r[--e] = 2), (r[--e] = 0), new u(r);
        })(t, (this.n.bitLength() + 7) >> 3);
        if (f(e)) return null;
        var r = this.doPublic(e);
        if (f(r)) return null;
        var n = r.toString(16);
        return 0 == (1 & n.length) ? n : "0" + n;
      }),
      t
    );
  })();
  "undefined" != typeof globalThis
    ? globalThis
    : "undefined" != typeof window
    ? window
    : "undefined" != typeof global
    ? global
    : "undefined" != typeof self && self;
  function l(t) {
    var e = { exports: {} };
    return t(e, e.exports), e.exports;
  }
  var d = l(function (t, e) {
      var r;
      t.exports = r =
        r ||
        (function (t, e) {
          var r =
              Object.create ||
              (function () {
                function t() {}
                return function (e) {
                  var r;
                  return (
                    (t.prototype = e), (r = new t()), (t.prototype = null), r
                  );
                };
              })(),
            n = {},
            i = (n.lib = {}),
            o = (i.Base = {
              extend: function (t) {
                var e = r(this);
                return (
                  t && e.mixIn(t),
                  (e.hasOwnProperty("init") && this.init !== e.init) ||
                    (e.init = function () {
                      e.$super.init.apply(this, arguments);
                    }),
                  (e.init.prototype = e),
                  (e.$super = this),
                  e
                );
              },
              create: function () {
                var t = this.extend();
                return t.init.apply(t, arguments), t;
              },
              init: function () {},
              mixIn: function (t) {
                for (var e in t) t.hasOwnProperty(e) && (this[e] = t[e]);
                t.hasOwnProperty("toString") && (this.toString = t.toString);
              },
              clone: function () {
                return this.init.prototype.extend(this);
              },
            }),
            s = (i.WordArray = o.extend({
              init: function (t, r) {
                (t = this.words = t || []),
                  (this.sigBytes = r != e ? r : 4 * t.length);
              },
              toString: function (t) {
                return (t || c).stringify(this);
              },
              concat: function (t) {
                var e = this.words,
                  r = t.words,
                  n = this.sigBytes,
                  i = t.sigBytes;
                if ((this.clamp(), n % 4))
                  for (var o = 0; o < i; o++) {
                    var s = (r[o >>> 2] >>> (24 - (o % 4) * 8)) & 255;
                    e[(n + o) >>> 2] |= s << (24 - ((n + o) % 4) * 8);
                  }
                else for (o = 0; o < i; o += 4) e[(n + o) >>> 2] = r[o >>> 2];
                return (this.sigBytes += i), this;
              },
              clamp: function () {
                var e = this.words,
                  r = this.sigBytes;
                (e[r >>> 2] &= 4294967295 << (32 - (r % 4) * 8)),
                  (e.length = t.ceil(r / 4));
              },
              clone: function () {
                var t = o.clone.call(this);
                return (t.words = this.words.slice(0)), t;
              },
              random: function (e) {
                for (
                  var r,
                    n = [],
                    i = function (e) {
                      e = e;
                      var r = 987654321,
                        n = 4294967295;
                      return function () {
                        var i =
                          (((r = (36969 * (65535 & r) + (r >> 16)) & n) << 16) +
                            (e = (18e3 * (65535 & e) + (e >> 16)) & n)) &
                          n;
                        return (
                          (i /= 4294967296),
                          (i += 0.5) * (t.random() > 0.5 ? 1 : -1)
                        );
                      };
                    },
                    o = 0;
                  o < e;
                  o += 4
                ) {
                  var a = i(4294967296 * (r || t.random()));
                  (r = 987654071 * a()), n.push((4294967296 * a()) | 0);
                }
                return new s.init(n, e);
              },
            })),
            a = (n.enc = {}),
            c = (a.Hex = {
              stringify: function (t) {
                for (
                  var e = t.words, r = t.sigBytes, n = [], i = 0;
                  i < r;
                  i++
                ) {
                  var o = (e[i >>> 2] >>> (24 - (i % 4) * 8)) & 255;
                  n.push((o >>> 4).toString(16)), n.push((15 & o).toString(16));
                }
                return n.join("");
              },
              parse: function (t) {
                for (var e = t.length, r = [], n = 0; n < e; n += 2)
                  r[n >>> 3] |=
                    parseInt(t.substr(n, 2), 16) << (24 - (n % 8) * 4);
                return new s.init(r, e / 2);
              },
            }),
            u = (a.Latin1 = {
              stringify: function (t) {
                for (
                  var e = t.words, r = t.sigBytes, n = [], i = 0;
                  i < r;
                  i++
                ) {
                  var o = (e[i >>> 2] >>> (24 - (i % 4) * 8)) & 255;
                  n.push(String.fromCharCode(o));
                }
                return n.join("");
              },
              parse: function (t) {
                for (var e = t.length, r = [], n = 0; n < e; n++)
                  r[n >>> 2] |= (255 & t.charCodeAt(n)) << (24 - (n % 4) * 8);
                return new s.init(r, e);
              },
            }),
            h = (a.Utf8 = {
              stringify: function (t) {
                try {
                  return decodeURIComponent(escape(u.stringify(t)));
                } catch (t) {
                  throw new Error("Malformed UTF-8 data");
                }
              },
              parse: function (t) {
                return u.parse(unescape(encodeURIComponent(t)));
              },
            }),
            f = (i.BufferedBlockAlgorithm = o.extend({
              reset: function () {
                (this._data = new s.init()), (this._nDataBytes = 0);
              },
              _append: function (t) {
                "string" == typeof t && (t = h.parse(t)),
                  this._data.concat(t),
                  (this._nDataBytes += t.sigBytes);
              },
              _process: function (e) {
                var r = this._data,
                  n = r.words,
                  i = r.sigBytes,
                  o = this.blockSize,
                  a = i / (4 * o),
                  c =
                    (a = e
                      ? t.ceil(a)
                      : t.max((0 | a) - this._minBufferSize, 0)) * o,
                  u = t.min(4 * c, i);
                if (c) {
                  for (var h = 0; h < c; h += o) this._doProcessBlock(n, h);
                  var f = n.splice(0, c);
                  r.sigBytes -= u;
                }
                return new s.init(f, u);
              },
              clone: function () {
                var t = o.clone.call(this);
                return (t._data = this._data.clone()), t;
              },
              _minBufferSize: 0,
            }));
          i.Hasher = f.extend({
            cfg: o.extend(),
            init: function (t) {
              (this.cfg = this.cfg.extend(t)), this.reset();
            },
            reset: function () {
              f.reset.call(this), this._doReset();
            },
            update: function (t) {
              return this._append(t), this._process(), this;
            },
            finalize: function (t) {
              return t && this._append(t), this._doFinalize();
            },
            blockSize: 16,
            _createHelper: function (t) {
              return function (e, r) {
                return new t.init(r).finalize(e);
              };
            },
            _createHmacHelper: function (t) {
              return function (e, r) {
                return new p.HMAC.init(t, r).finalize(e);
              };
            },
          });
          var p = (n.algo = {});
          return n;
        })(Math);
    }),
    v =
      (l(function (t, e) {
        var r;
        t.exports =
          ((r = d),
          (function () {
            var t = r,
              e = t.lib.WordArray;
            function n(t, r, n) {
              for (var i = [], o = 0, s = 0; s < r; s++)
                if (s % 4) {
                  var a = n[t.charCodeAt(s - 1)] << ((s % 4) * 2),
                    c = n[t.charCodeAt(s)] >>> (6 - (s % 4) * 2);
                  (i[o >>> 2] |= (a | c) << (24 - (o % 4) * 8)), o++;
                }
              return e.create(i, o);
            }
            t.enc.Base64 = {
              stringify: function (t) {
                var e = t.words,
                  r = t.sigBytes,
                  n = this._map;
                t.clamp();
                for (var i = [], o = 0; o < r; o += 3)
                  for (
                    var s =
                        (((e[o >>> 2] >>> (24 - (o % 4) * 8)) & 255) << 16) |
                        (((e[(o + 1) >>> 2] >>> (24 - ((o + 1) % 4) * 8)) &
                          255) <<
                          8) |
                        ((e[(o + 2) >>> 2] >>> (24 - ((o + 2) % 4) * 8)) & 255),
                      a = 0;
                    a < 4 && o + 0.75 * a < r;
                    a++
                  )
                    i.push(n.charAt((s >>> (6 * (3 - a))) & 63));
                var c = n.charAt(64);
                if (c) for (; i.length % 4; ) i.push(c);
                return i.join("");
              },
              parse: function (t) {
                var e = t.length,
                  r = this._map,
                  i = this._reverseMap;
                if (!i) {
                  i = this._reverseMap = [];
                  for (var o = 0; o < r.length; o++) i[r.charCodeAt(o)] = o;
                }
                var s = r.charAt(64);
                if (s) {
                  var a = t.indexOf(s);
                  -1 !== a && (e = a);
                }
                return n(t, e, i);
              },
              _map:
                "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=",
            };
          })(),
          r.enc.Base64);
      }),
      l(function (t, e) {
        var r;
        t.exports =
          ((r = d),
          (function (t) {
            var e = r,
              n = e.lib,
              i = n.WordArray,
              o = n.Hasher,
              s = e.algo,
              a = [];
            !(function () {
              for (var e = 0; e < 64; e++)
                a[e] = (4294967296 * t.abs(t.sin(e + 1))) | 0;
            })();
            var c = (s.MD5 = o.extend({
              _doReset: function () {
                this._hash = new i.init([
                  1732584193,
                  4023233417,
                  2562383102,
                  271733878,
                ]);
              },
              _doProcessBlock: function (t, e) {
                for (var r = 0; r < 16; r++) {
                  var n = e + r,
                    i = t[n];
                  t[n] =
                    (16711935 & ((i << 8) | (i >>> 24))) |
                    (4278255360 & ((i << 24) | (i >>> 8)));
                }
                var o = this._hash.words,
                  s = t[e + 0],
                  c = t[e + 1],
                  l = t[e + 2],
                  d = t[e + 3],
                  v = t[e + 4],
                  m = t[e + 5],
                  y = t[e + 6],
                  g = t[e + 7],
                  _ = t[e + 8],
                  b = t[e + 9],
                  w = t[e + 10],
                  S = t[e + 11],
                  B = t[e + 12],
                  T = t[e + 13],
                  D = t[e + 14],
                  k = t[e + 15],
                  x = o[0],
                  O = o[1],
                  E = o[2],
                  M = o[3];
                (x = u(x, O, E, M, s, 7, a[0])),
                  (M = u(M, x, O, E, c, 12, a[1])),
                  (E = u(E, M, x, O, l, 17, a[2])),
                  (O = u(O, E, M, x, d, 22, a[3])),
                  (x = u(x, O, E, M, v, 7, a[4])),
                  (M = u(M, x, O, E, m, 12, a[5])),
                  (E = u(E, M, x, O, y, 17, a[6])),
                  (O = u(O, E, M, x, g, 22, a[7])),
                  (x = u(x, O, E, M, _, 7, a[8])),
                  (M = u(M, x, O, E, b, 12, a[9])),
                  (E = u(E, M, x, O, w, 17, a[10])),
                  (O = u(O, E, M, x, S, 22, a[11])),
                  (x = u(x, O, E, M, B, 7, a[12])),
                  (M = u(M, x, O, E, T, 12, a[13])),
                  (E = u(E, M, x, O, D, 17, a[14])),
                  (x = h(
                    x,
                    (O = u(O, E, M, x, k, 22, a[15])),
                    E,
                    M,
                    c,
                    5,
                    a[16]
                  )),
                  (M = h(M, x, O, E, y, 9, a[17])),
                  (E = h(E, M, x, O, S, 14, a[18])),
                  (O = h(O, E, M, x, s, 20, a[19])),
                  (x = h(x, O, E, M, m, 5, a[20])),
                  (M = h(M, x, O, E, w, 9, a[21])),
                  (E = h(E, M, x, O, k, 14, a[22])),
                  (O = h(O, E, M, x, v, 20, a[23])),
                  (x = h(x, O, E, M, b, 5, a[24])),
                  (M = h(M, x, O, E, D, 9, a[25])),
                  (E = h(E, M, x, O, d, 14, a[26])),
                  (O = h(O, E, M, x, _, 20, a[27])),
                  (x = h(x, O, E, M, T, 5, a[28])),
                  (M = h(M, x, O, E, l, 9, a[29])),
                  (E = h(E, M, x, O, g, 14, a[30])),
                  (x = f(
                    x,
                    (O = h(O, E, M, x, B, 20, a[31])),
                    E,
                    M,
                    m,
                    4,
                    a[32]
                  )),
                  (M = f(M, x, O, E, _, 11, a[33])),
                  (E = f(E, M, x, O, S, 16, a[34])),
                  (O = f(O, E, M, x, D, 23, a[35])),
                  (x = f(x, O, E, M, c, 4, a[36])),
                  (M = f(M, x, O, E, v, 11, a[37])),
                  (E = f(E, M, x, O, g, 16, a[38])),
                  (O = f(O, E, M, x, w, 23, a[39])),
                  (x = f(x, O, E, M, T, 4, a[40])),
                  (M = f(M, x, O, E, s, 11, a[41])),
                  (E = f(E, M, x, O, d, 16, a[42])),
                  (O = f(O, E, M, x, y, 23, a[43])),
                  (x = f(x, O, E, M, b, 4, a[44])),
                  (M = f(M, x, O, E, B, 11, a[45])),
                  (E = f(E, M, x, O, k, 16, a[46])),
                  (x = p(
                    x,
                    (O = f(O, E, M, x, l, 23, a[47])),
                    E,
                    M,
                    s,
                    6,
                    a[48]
                  )),
                  (M = p(M, x, O, E, g, 10, a[49])),
                  (E = p(E, M, x, O, D, 15, a[50])),
                  (O = p(O, E, M, x, m, 21, a[51])),
                  (x = p(x, O, E, M, B, 6, a[52])),
                  (M = p(M, x, O, E, d, 10, a[53])),
                  (E = p(E, M, x, O, w, 15, a[54])),
                  (O = p(O, E, M, x, c, 21, a[55])),
                  (x = p(x, O, E, M, _, 6, a[56])),
                  (M = p(M, x, O, E, k, 10, a[57])),
                  (E = p(E, M, x, O, y, 15, a[58])),
                  (O = p(O, E, M, x, T, 21, a[59])),
                  (x = p(x, O, E, M, v, 6, a[60])),
                  (M = p(M, x, O, E, S, 10, a[61])),
                  (E = p(E, M, x, O, l, 15, a[62])),
                  (O = p(O, E, M, x, b, 21, a[63])),
                  (o[0] = (o[0] + x) | 0),
                  (o[1] = (o[1] + O) | 0),
                  (o[2] = (o[2] + E) | 0),
                  (o[3] = (o[3] + M) | 0);
              },
              _doFinalize: function () {
                var e = this._data,
                  r = e.words,
                  n = 8 * this._nDataBytes,
                  i = 8 * e.sigBytes;
                r[i >>> 5] |= 128 << (24 - (i % 32));
                var o = t.floor(n / 4294967296),
                  s = n;
                (r[15 + (((i + 64) >>> 9) << 4)] =
                  (16711935 & ((o << 8) | (o >>> 24))) |
                  (4278255360 & ((o << 24) | (o >>> 8)))),
                  (r[14 + (((i + 64) >>> 9) << 4)] =
                    (16711935 & ((s << 8) | (s >>> 24))) |
                    (4278255360 & ((s << 24) | (s >>> 8)))),
                  (e.sigBytes = 4 * (r.length + 1)),
                  this._process();
                for (var a = this._hash, c = a.words, u = 0; u < 4; u++) {
                  var h = c[u];
                  c[u] =
                    (16711935 & ((h << 8) | (h >>> 24))) |
                    (4278255360 & ((h << 24) | (h >>> 8)));
                }
                return a;
              },
              clone: function () {
                var t = o.clone.call(this);
                return (t._hash = this._hash.clone()), t;
              },
            }));
            function u(t, e, r, n, i, o, s) {
              var a = t + ((e & r) | (~e & n)) + i + s;
              return ((a << o) | (a >>> (32 - o))) + e;
            }
            function h(t, e, r, n, i, o, s) {
              var a = t + ((e & n) | (r & ~n)) + i + s;
              return ((a << o) | (a >>> (32 - o))) + e;
            }
            function f(t, e, r, n, i, o, s) {
              var a = t + (e ^ r ^ n) + i + s;
              return ((a << o) | (a >>> (32 - o))) + e;
            }
            function p(t, e, r, n, i, o, s) {
              var a = t + (r ^ (e | ~n)) + i + s;
              return ((a << o) | (a >>> (32 - o))) + e;
            }
            (e.MD5 = o._createHelper(c)), (e.HmacMD5 = o._createHmacHelper(c));
          })(Math),
          r.MD5);
      }),
      l(function (t, e) {
        var r, n, i, o, s, a, c, u;
        t.exports =
          ((n = (r = u = d).lib),
          (i = n.WordArray),
          (o = n.Hasher),
          (s = r.algo),
          (a = []),
          (c = s.SHA1 = o.extend({
            _doReset: function () {
              this._hash = new i.init([
                1732584193,
                4023233417,
                2562383102,
                271733878,
                3285377520,
              ]);
            },
            _doProcessBlock: function (t, e) {
              for (
                var r = this._hash.words,
                  n = r[0],
                  i = r[1],
                  o = r[2],
                  s = r[3],
                  c = r[4],
                  u = 0;
                u < 80;
                u++
              ) {
                if (u < 16) a[u] = 0 | t[e + u];
                else {
                  var h = a[u - 3] ^ a[u - 8] ^ a[u - 14] ^ a[u - 16];
                  a[u] = (h << 1) | (h >>> 31);
                }
                var f = ((n << 5) | (n >>> 27)) + c + a[u];
                (f +=
                  u < 20
                    ? 1518500249 + ((i & o) | (~i & s))
                    : u < 40
                    ? 1859775393 + (i ^ o ^ s)
                    : u < 60
                    ? ((i & o) | (i & s) | (o & s)) - 1894007588
                    : (i ^ o ^ s) - 899497514),
                  (c = s),
                  (s = o),
                  (o = (i << 30) | (i >>> 2)),
                  (i = n),
                  (n = f);
              }
              (r[0] = (r[0] + n) | 0),
                (r[1] = (r[1] + i) | 0),
                (r[2] = (r[2] + o) | 0),
                (r[3] = (r[3] + s) | 0),
                (r[4] = (r[4] + c) | 0);
            },
            _doFinalize: function () {
              var t = this._data,
                e = t.words,
                r = 8 * this._nDataBytes,
                n = 8 * t.sigBytes;
              return (
                (e[n >>> 5] |= 128 << (24 - (n % 32))),
                (e[14 + (((n + 64) >>> 9) << 4)] = Math.floor(r / 4294967296)),
                (e[15 + (((n + 64) >>> 9) << 4)] = r),
                (t.sigBytes = 4 * e.length),
                this._process(),
                this._hash
              );
            },
            clone: function () {
              var t = o.clone.call(this);
              return (t._hash = this._hash.clone()), t;
            },
          })),
          (r.SHA1 = o._createHelper(c)),
          (r.HmacSHA1 = o._createHmacHelper(c)),
          u.SHA1);
      }),
      l(function (t, e) {
        var r, n, i;
        t.exports =
          ((n = (r = d).lib.Base),
          (i = r.enc.Utf8),
          void (r.algo.HMAC = n.extend({
            init: function (t, e) {
              (t = this._hasher = new t.init()),
                "string" == typeof e && (e = i.parse(e));
              var r = t.blockSize,
                n = 4 * r;
              e.sigBytes > n && (e = t.finalize(e)), e.clamp();
              for (
                var o = (this._oKey = e.clone()),
                  s = (this._iKey = e.clone()),
                  a = o.words,
                  c = s.words,
                  u = 0;
                u < r;
                u++
              )
                (a[u] ^= 1549556828), (c[u] ^= 909522486);
              (o.sigBytes = s.sigBytes = n), this.reset();
            },
            reset: function () {
              var t = this._hasher;
              t.reset(), t.update(this._iKey);
            },
            update: function (t) {
              return this._hasher.update(t), this;
            },
            finalize: function (t) {
              var e = this._hasher,
                r = e.finalize(t);
              return e.reset(), e.finalize(this._oKey.clone().concat(r));
            },
          })));
      }),
      l(function (t, e) {
        var r, n, i, o, s, a, c, u;
        t.exports =
          ((n = (r = u = d).lib),
          (i = n.Base),
          (o = n.WordArray),
          (s = r.algo),
          (a = s.MD5),
          (c = s.EvpKDF = i.extend({
            cfg: i.extend({ keySize: 4, hasher: a, iterations: 1 }),
            init: function (t) {
              this.cfg = this.cfg.extend(t);
            },
            compute: function (t, e) {
              for (
                var r = this.cfg,
                  n = r.hasher.create(),
                  i = o.create(),
                  s = i.words,
                  a = r.keySize,
                  c = r.iterations;
                s.length < a;

              ) {
                u && n.update(u);
                var u = n.update(t).finalize(e);
                n.reset();
                for (var h = 1; h < c; h++) (u = n.finalize(u)), n.reset();
                i.concat(u);
              }
              return (i.sigBytes = 4 * a), i;
            },
          })),
          (r.EvpKDF = function (t, e, r) {
            return c.create(r).compute(t, e);
          }),
          u.EvpKDF);
      }),
      l(function (t, e) {
        var r;
        t.exports = void (
          (r = d).lib.Cipher ||
          (function (t) {
            var e = r,
              n = e.lib,
              i = n.Base,
              o = n.WordArray,
              s = n.BufferedBlockAlgorithm,
              a = e.enc;
            a.Utf8;
            var c = a.Base64,
              u = e.algo.EvpKDF,
              h = (n.Cipher = s.extend({
                cfg: i.extend(),
                createEncryptor: function (t, e) {
                  return this.create(this._ENC_XFORM_MODE, t, e);
                },
                createDecryptor: function (t, e) {
                  return this.create(this._DEC_XFORM_MODE, t, e);
                },
                init: function (t, e, r) {
                  (this.cfg = this.cfg.extend(r)),
                    (this._xformMode = t),
                    (this._key = e),
                    this.reset();
                },
                reset: function () {
                  s.reset.call(this), this._doReset();
                },
                process: function (t) {
                  return this._append(t), this._process();
                },
                finalize: function (t) {
                  return t && this._append(t), this._doFinalize();
                },
                keySize: 4,
                ivSize: 4,
                _ENC_XFORM_MODE: 1,
                _DEC_XFORM_MODE: 2,
                _createHelper: (function () {
                  function t(t) {
                    return "string" == typeof t ? _ : y;
                  }
                  return function (e) {
                    return {
                      encrypt: function (r, n, i) {
                        return t(n).encrypt(e, r, n, i);
                      },
                      decrypt: function (r, n, i) {
                        return t(n).decrypt(e, r, n, i);
                      },
                    };
                  };
                })(),
              }));
            n.StreamCipher = h.extend({
              _doFinalize: function () {
                return this._process(!0);
              },
              blockSize: 1,
            });
            var f = (e.mode = {}),
              p = (n.BlockCipherMode = i.extend({
                createEncryptor: function (t, e) {
                  return this.Encryptor.create(t, e);
                },
                createDecryptor: function (t, e) {
                  return this.Decryptor.create(t, e);
                },
                init: function (t, e) {
                  (this._cipher = t), (this._iv = e);
                },
              })),
              l = (f.CBC = (function () {
                var e = p.extend();
                function r(e, r, n) {
                  var i = this._iv;
                  if (i) {
                    var o = i;
                    this._iv = t;
                  } else o = this._prevBlock;
                  for (var s = 0; s < n; s++) e[r + s] ^= o[s];
                }
                return (
                  (e.Encryptor = e.extend({
                    processBlock: function (t, e) {
                      var n = this._cipher,
                        i = n.blockSize;
                      r.call(this, t, e, i),
                        n.encryptBlock(t, e),
                        (this._prevBlock = t.slice(e, e + i));
                    },
                  })),
                  (e.Decryptor = e.extend({
                    processBlock: function (t, e) {
                      var n = this._cipher,
                        i = n.blockSize,
                        o = t.slice(e, e + i);
                      n.decryptBlock(t, e),
                        r.call(this, t, e, i),
                        (this._prevBlock = o);
                    },
                  })),
                  e
                );
              })()),
              d = ((e.pad = {}).Pkcs7 = {
                pad: function (t, e) {
                  for (
                    var r = 4 * e,
                      n = r - (t.sigBytes % r),
                      i = (n << 24) | (n << 16) | (n << 8) | n,
                      s = [],
                      a = 0;
                    a < n;
                    a += 4
                  )
                    s.push(i);
                  var c = o.create(s, n);
                  t.concat(c);
                },
                unpad: function (t) {
                  var e = 255 & t.words[(t.sigBytes - 1) >>> 2];
                  t.sigBytes -= e;
                },
              });
            n.BlockCipher = h.extend({
              cfg: h.cfg.extend({ mode: l, padding: d }),
              reset: function () {
                h.reset.call(this);
                var t = this.cfg,
                  e = t.iv,
                  r = t.mode;
                if (this._xformMode == this._ENC_XFORM_MODE)
                  var n = r.createEncryptor;
                else (n = r.createDecryptor), (this._minBufferSize = 1);
                this._mode && this._mode.__creator == n
                  ? this._mode.init(this, e && e.words)
                  : ((this._mode = n.call(r, this, e && e.words)),
                    (this._mode.__creator = n));
              },
              _doProcessBlock: function (t, e) {
                this._mode.processBlock(t, e);
              },
              _doFinalize: function () {
                var t = this.cfg.padding;
                if (this._xformMode == this._ENC_XFORM_MODE) {
                  t.pad(this._data, this.blockSize);
                  var e = this._process(!0);
                } else (e = this._process(!0)), t.unpad(e);
                return e;
              },
              blockSize: 4,
            });
            var v = (n.CipherParams = i.extend({
                init: function (t) {
                  this.mixIn(t);
                },
                toString: function (t) {
                  return (t || this.formatter).stringify(this);
                },
              })),
              m = ((e.format = {}).OpenSSL = {
                stringify: function (t) {
                  var e = t.ciphertext,
                    r = t.salt;
                  if (r)
                    var n = o
                      .create([1398893684, 1701076831])
                      .concat(r)
                      .concat(e);
                  else n = e;
                  return n.toString(c);
                },
                parse: function (t) {
                  var e = c.parse(t),
                    r = e.words;
                  if (1398893684 == r[0] && 1701076831 == r[1]) {
                    var n = o.create(r.slice(2, 4));
                    r.splice(0, 4), (e.sigBytes -= 16);
                  }
                  return v.create({ ciphertext: e, salt: n });
                },
              }),
              y = (n.SerializableCipher = i.extend({
                cfg: i.extend({ format: m }),
                encrypt: function (t, e, r, n) {
                  n = this.cfg.extend(n);
                  var i = t.createEncryptor(r, n),
                    o = i.finalize(e),
                    s = i.cfg;
                  return v.create({
                    ciphertext: o,
                    key: r,
                    iv: s.iv,
                    algorithm: t,
                    mode: s.mode,
                    padding: s.padding,
                    blockSize: t.blockSize,
                    formatter: n.format,
                  });
                },
                decrypt: function (t, e, r, n) {
                  return (
                    (n = this.cfg.extend(n)),
                    (e = this._parse(e, n.format)),
                    t.createDecryptor(r, n).finalize(e.ciphertext)
                  );
                },
                _parse: function (t, e) {
                  return "string" == typeof t ? e.parse(t, this) : t;
                },
              })),
              g = ((e.kdf = {}).OpenSSL = {
                execute: function (t, e, r, n) {
                  n || (n = o.random(8));
                  var i = u.create({ keySize: e + r }).compute(t, n),
                    s = o.create(i.words.slice(e), 4 * r);
                  return (
                    (i.sigBytes = 4 * e), v.create({ key: i, iv: s, salt: n })
                  );
                },
              }),
              _ = (n.PasswordBasedCipher = y.extend({
                cfg: y.cfg.extend({ kdf: g }),
                encrypt: function (t, e, r, n) {
                  var i = (n = this.cfg.extend(n)).kdf.execute(
                    r,
                    t.keySize,
                    t.ivSize
                  );
                  n.iv = i.iv;
                  var o = y.encrypt.call(this, t, e, i.key, n);
                  return o.mixIn(i), o;
                },
                decrypt: function (t, e, r, n) {
                  (n = this.cfg.extend(n)), (e = this._parse(e, n.format));
                  var i = n.kdf.execute(r, t.keySize, t.ivSize, e.salt);
                  return (n.iv = i.iv), y.decrypt.call(this, t, e, i.key, n);
                },
              }));
          })()
        );
      }),
      l(function (t, e) {
        var r;
        t.exports =
          ((r = d),
          (function () {
            var t = r,
              e = t.lib.BlockCipher,
              n = t.algo,
              i = [],
              o = [],
              s = [],
              a = [],
              c = [],
              u = [],
              h = [],
              f = [],
              p = [],
              l = [];
            !(function () {
              for (var t = [], e = 0; e < 256; e++)
                t[e] = e < 128 ? e << 1 : (e << 1) ^ 283;
              var r = 0,
                n = 0;
              for (e = 0; e < 256; e++) {
                var d = n ^ (n << 1) ^ (n << 2) ^ (n << 3) ^ (n << 4);
                (d = (d >>> 8) ^ (255 & d) ^ 99), (i[r] = d), (o[d] = r);
                var v = t[r],
                  m = t[v],
                  y = t[m],
                  g = (257 * t[d]) ^ (16843008 * d);
                (s[r] = (g << 24) | (g >>> 8)),
                  (a[r] = (g << 16) | (g >>> 16)),
                  (c[r] = (g << 8) | (g >>> 24)),
                  (u[r] = g),
                  (g =
                    (16843009 * y) ^ (65537 * m) ^ (257 * v) ^ (16843008 * r)),
                  (h[d] = (g << 24) | (g >>> 8)),
                  (f[d] = (g << 16) | (g >>> 16)),
                  (p[d] = (g << 8) | (g >>> 24)),
                  (l[d] = g),
                  r ? ((r = v ^ t[t[t[y ^ v]]]), (n ^= t[t[n]])) : (r = n = 1);
              }
            })();
            var d = [0, 1, 2, 4, 8, 16, 32, 64, 128, 27, 54],
              v = (n.AES = e.extend({
                _doReset: function () {
                  if (!this._nRounds || this._keyPriorReset !== this._key) {
                    for (
                      var t = (this._keyPriorReset = this._key),
                        e = t.words,
                        r = t.sigBytes / 4,
                        n = 4 * ((this._nRounds = r + 6) + 1),
                        o = (this._keySchedule = []),
                        s = 0;
                      s < n;
                      s++
                    )
                      if (s < r) o[s] = e[s];
                      else {
                        var a = o[s - 1];
                        s % r
                          ? r > 6 &&
                            s % r == 4 &&
                            (a =
                              (i[a >>> 24] << 24) |
                              (i[(a >>> 16) & 255] << 16) |
                              (i[(a >>> 8) & 255] << 8) |
                              i[255 & a])
                          : ((a =
                              (i[(a = (a << 8) | (a >>> 24)) >>> 24] << 24) |
                              (i[(a >>> 16) & 255] << 16) |
                              (i[(a >>> 8) & 255] << 8) |
                              i[255 & a]),
                            (a ^= d[(s / r) | 0] << 24)),
                          (o[s] = o[s - r] ^ a);
                      }
                    for (var c = (this._invKeySchedule = []), u = 0; u < n; u++)
                      (s = n - u),
                        (a = u % 4 ? o[s] : o[s - 4]),
                        (c[u] =
                          u < 4 || s <= 4
                            ? a
                            : h[i[a >>> 24]] ^
                              f[i[(a >>> 16) & 255]] ^
                              p[i[(a >>> 8) & 255]] ^
                              l[i[255 & a]]);
                  }
                },
                encryptBlock: function (t, e) {
                  this._doCryptBlock(t, e, this._keySchedule, s, a, c, u, i);
                },
                decryptBlock: function (t, e) {
                  var r = t[e + 1];
                  (t[e + 1] = t[e + 3]),
                    (t[e + 3] = r),
                    this._doCryptBlock(
                      t,
                      e,
                      this._invKeySchedule,
                      h,
                      f,
                      p,
                      l,
                      o
                    ),
                    (r = t[e + 1]),
                    (t[e + 1] = t[e + 3]),
                    (t[e + 3] = r);
                },
                _doCryptBlock: function (t, e, r, n, i, o, s, a) {
                  for (
                    var c = this._nRounds,
                      u = t[e] ^ r[0],
                      h = t[e + 1] ^ r[1],
                      f = t[e + 2] ^ r[2],
                      p = t[e + 3] ^ r[3],
                      l = 4,
                      d = 1;
                    d < c;
                    d++
                  ) {
                    var v =
                        n[u >>> 24] ^
                        i[(h >>> 16) & 255] ^
                        o[(f >>> 8) & 255] ^
                        s[255 & p] ^
                        r[l++],
                      m =
                        n[h >>> 24] ^
                        i[(f >>> 16) & 255] ^
                        o[(p >>> 8) & 255] ^
                        s[255 & u] ^
                        r[l++],
                      y =
                        n[f >>> 24] ^
                        i[(p >>> 16) & 255] ^
                        o[(u >>> 8) & 255] ^
                        s[255 & h] ^
                        r[l++],
                      g =
                        n[p >>> 24] ^
                        i[(u >>> 16) & 255] ^
                        o[(h >>> 8) & 255] ^
                        s[255 & f] ^
                        r[l++];
                    (u = v), (h = m), (f = y), (p = g);
                  }
                  (v =
                    ((a[u >>> 24] << 24) |
                      (a[(h >>> 16) & 255] << 16) |
                      (a[(f >>> 8) & 255] << 8) |
                      a[255 & p]) ^
                    r[l++]),
                    (m =
                      ((a[h >>> 24] << 24) |
                        (a[(f >>> 16) & 255] << 16) |
                        (a[(p >>> 8) & 255] << 8) |
                        a[255 & u]) ^
                      r[l++]),
                    (y =
                      ((a[f >>> 24] << 24) |
                        (a[(p >>> 16) & 255] << 16) |
                        (a[(u >>> 8) & 255] << 8) |
                        a[255 & h]) ^
                      r[l++]),
                    (g =
                      ((a[p >>> 24] << 24) |
                        (a[(u >>> 16) & 255] << 16) |
                        (a[(h >>> 8) & 255] << 8) |
                        a[255 & f]) ^
                      r[l++]),
                    (t[e] = v),
                    (t[e + 1] = m),
                    (t[e + 2] = y),
                    (t[e + 3] = g);
                },
                keySize: 8,
              }));
            t.AES = e._createHelper(v);
          })(),
          r.AES);
      })),
    m = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
  function y(t) {
    var e,
      r,
      n = "";
    for (e = 0; e + 3 <= t.length; e += 3)
      (r = parseInt(t.substring(e, e + 3), 16)),
        (n += m.charAt(r >> 6) + m.charAt(63 & r));
    for (
      e + 1 === t.length
        ? ((r = parseInt(t.substring(e, e + 1), 16)), (n += m.charAt(r << 2)))
        : e + 2 === t.length &&
          ((r = parseInt(t.substring(e, e + 2), 16)),
          (n += m.charAt(r >> 2) + m.charAt((3 & r) << 4)));
      (3 & n.length) > 0;

    )
      n += "=";
    return n;
  }
  var g,
    _ =
      ((g =
        "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ~!@#$%^&*()_+-/"),
      function (t) {
        for (var e = []; t > 0; )
          e.push(g.charAt(Math.floor(Math.random() * (g.length + 1)))), t--;
        return e.join("");
      });
  function b(t, e) {
    var r = e.cipherKey,
      n = e.publicKey,
      i = e.cipherToken,
      o = e.timeBias;
    if (!r || !n || !i) return t;
    var s = new p();
    s.setPublic(n, "10001");
    var c = _(501),
      u = s.encrypt(c);
    if (!u) return t;
    var h = {};
    (h[i] = Math.floor(Date.now() / 1e3) + o), Object.assign(h, t);
    var f = v.encrypt(a(h), c).toString();
    if (!f) return t;
    var l = {};
    return (l[r] = { rsa: y(u), aes: f }), l;
  }
  var w = (function () {
    function t(t) {
      this.env = t;
    }
    var r = t.prototype;
    return (
      (r.request = function (t) {
        var e = this,
          r = this.prepare(t);
        return (Array.isArray(t.encryption) && !this.env.isSecure()
          ? this.encryptParams(r, t.encryption).catch(function () {})
          : Promise.resolve()
        ).then(function () {
          return e.doRequest(r);
        });
      }),
      (r.encrypt = function (t, r) {
        void 0 === r && (r = {}), (t = JSON.parse(JSON.stringify(t)));
        var n = e({}, r, { params: t });
        return this.encryptParams(n, Object.keys(t)).then(function () {
          var t = n.params;
          if ("raw" !== r.requestFormat)
            for (var e in t) o(t, e) && (t[e] = JSON.stringify(t[e]));
          return t;
        });
      }),
      (r.createRequestConfig = function (t) {
        var e;
        return (
          (e =
            "webapi" === t.requestFormat
              ? Object.assign(B(t), S(t.params))
              : t.params) &&
            e.compound &&
            (e.compound = JSON.stringify(
              JSON.parse(e.compound).map(function (t) {
                var e = Object.assign({}, t, t.params);
                return delete e.params, e;
              })
            )),
          {
            url: t.url || this.env.getBaseURL() + "webapi/entry.cgi/" + t.api,
            method: t.requestMethod,
            params: e,
            headers: this.getHeaders(t),
            options: t,
            timeout: t.timeout,
            signal: t.signal,
          }
        );
      }),
      (r.prepare = function (t) {
        var r,
          n = t.compound;
        if (n) {
          var i = n.params || [];
          r = {
            api: "SYNO.Entry.Request",
            method: "request",
            version: 1,
            params: {
              stop_when_error: !0 === n.stopwhenerror,
              mode: "parallel" === n.mode ? n.mode : "sequential",
              compound: i.map(T),
            },
          };
        } else r = T(t);
        return e({}, r, {
          headers: t.headers,
          url: t.url,
          requestFormat: t.requestFormat
            ? t.requestFormat.toLowerCase()
            : "webapi",
          requestMethod: t.requestMethod || "POST",
          responseFormat: t.responseFormat
            ? t.responseFormat.toLowerCase()
            : "webapi",
          timeout: t.timeout,
          signal: t.signal,
        });
      }),
      (r.doRequest = function (t) {
        var e = this;
        return new Promise(function (r, n) {
          e.requestAdapter(e.createRequestConfig(t), function (t, e, i) {
            if (e)
              try {
                i = JSON.parse(i);
              } catch (t) {}
            var o,
              a = !1,
              c = null;
            return (
              "raw" === t.responseFormat
                ? ((a = e), (c = i))
                : ((o = i),
                  "[object Object]" == Object.prototype.toString.call(o)
                    ? (c = (a = i.success) ? i.data : i.error)
                    : s(i) && ((a = !1), (c = i))),
              a ? r(c) : n(c)
            );
          });
        });
      }),
      (r.encryptParams = function (t, r, n) {
        var i = b,
          s = !1;
        function a(e, n, a) {
          if (e.params) {
            for (
              var c = Object.assign({}, e.params), u = {}, h = !1, f = 0;
              f < r.length;
              f++
            ) {
              var p = r[f];
              if (o(e.params, p)) {
                var l = e.params[p];
                "raw" !== t.requestFormat &&
                  (l = "string" == typeof l ? JSON.stringify(l) : l),
                  (u[p] = l),
                  delete c[p],
                  (h = !0);
              }
            }
            if (h) {
              var d = i(u, n);
              d[n.cipherKey] || (s = !0),
                "raw" === t.requestFormat && (d = S(d)),
                a && (d = S(d)),
                (e.params = Object.assign(c, d));
            }
          }
        }
        var c = { api: "SYNO.API.Encryption", method: "getinfo", version: 1 },
          u = this.env.isLegacyMode();
        return this.doRequest(
          e(
            {},
            u
              ? {
                  url: "webapi/encryption.cgi/SYNO.API.Encryption",
                  params: e({}, c, { format: "module" }),
                  requestFormat: "raw",
                }
              : e({}, c, { params: { format: "module" } }),
            { headers: t.headers }
          )
        )
          .then(function (e) {
            var r = {
                cipherKey: e.cipherkey,
                publicKey: e.public_key,
                cipherToken: e.ciphertoken,
                timeBias: e.server_time - Math.floor(Date.now() / 1e3),
              },
              n = t.params.compound;
            if (n)
              return new Promise(function (t) {
                var e = 0;
                !(function i() {
                  for (var o = Math.min(n.length, e + 5); e < o; e++)
                    a(n[e], r, !0);
                  e < n.length ? setTimeout(i, 80) : t();
                })();
              });
            a(t, r, !1);
          })
          .then(function () {
            return s ? Promise.reject() : Promise.resolve();
          });
      }),
      (r.getHeaders = function (t) {
        return Object.assign(
          {
            "Content-Type": "application/x-www-form-urlencoded; charset=UTF-8",
          },
          this.env.getRequestHeaders(),
          t.headers
        );
      }),
      (r.createAuthConfig = function (t) {
        var r = {
            api: "SYNO.API.Auth",
            version: t.version || 6,
            method: t.method || "login",
          },
          n = Object.keys(t).reduce(function (e, r) {
            return -1 === ["baseURL", "version"].indexOf(r) && (e[r] = t[r]), e;
          }, {}),
          i = t.baseURL || this.env.getBaseURL();
        if (this.env.isLegacyMode()) {
          i += "webapi/auth.cgi";
          var o = t.enable_syno_token;
          o && (i += "?enable_syno_token=" + o);
        } else i += "webapi/entry.cgi/" + r.api;
        return { url: i, params: e({}, n, r), requestFormat: "raw" };
      }),
      (r.auth = function (t) {
        return this.request(this.createAuthConfig(t));
      }),
      (r.requestAdapter = function () {}),
      t
    );
  })();
  function S(t) {
    var e = {};
    for (var r in t) o(t, r) && (e[r] = JSON.stringify(t[r]));
    return e;
  }
  function B(t) {
    return { api: t.api, method: t.method, version: t.version };
  }
  function T(t) {
    var e = B(t);
    return t.params && (e.params = t.params), e;
  }
  var D = (function () {
      function e(t) {}
      var r,
        n,
        i,
        o = e.prototype;
      return (
        (o.request = function (t) {
          return this.manager.request(t);
        }),
        (o.auth = function (t) {
          return this.manager.auth(t);
        }),
        (o.download = function (t) {
          t.onError && t.onError(new Error("unsupported"));
        }),
        (o.encrypt = function (t, e) {
          return this.manager.encrypt(t, e);
        }),
        (o.create = function (t) {
          return new this.constructor(t);
        }),
        (r = e),
        (n = [
          {
            key: "env",
            get: function () {
              return this.manager.env;
            },
          },
        ]) && t(r.prototype, n),
        i && t(r, i),
        e
      );
    })(),
    k = (function () {
      function t() {
        (this.aborted = !1), (this._handlers = {});
      }
      var e = t.prototype;
      return (
        (e.addEventListener = function (t, e) {
          this._handlers[t] || (this._handlers[t] = []),
            this._handlers[t].push(e);
        }),
        (e.removeEventListener = function (t, e) {
          var r = this._handlers[t];
          if (r) {
            var n = r.indexOf(e);
            n > -1 && r.splice(n, 1);
          }
        }),
        (e.emit = function (t) {
          var e = this._handlers[t];
          e &&
            e.forEach(function (t) {
              return t();
            });
        }),
        t
      );
    })(),
    x = (function () {
      function t() {
        this.signal = new k();
      }
      return (
        (t.prototype.abort = function () {
          var t = this.signal;
          t.aborted || (t.emit("abort"), (t.aborted = !0));
        }),
        t
      );
    })();
  function O(t) {
    return { env: t.env };
  }
  function E(t, e) {
    var r = e.callback || function () {},
      n = e.scope;
    t.then(
      function (t) {
        r.call(n, !0, t);
      },
      function (t) {
        r.call(n, !1, t);
      }
    );
  }
  function M(t) {
    return e({}, O(t), {
      request: function (e) {
        E(t.request(e), e);
      },
      auth: function (r, n, i) {
        n && (r = e({}, r, { callback: n, scope: i })), E(t.auth(r), r);
      },
      download: function (e) {
        t.download(e);
      },
      encrypt: function (e, r, n, i) {
        "function" == typeof r && ((i = n), (n = r), (r = {})),
          E(t.encrypt(e, r), { callback: n, scope: i });
      },
    });
  }
  function R(t) {
    return e({}, C(t), {
      create: function () {
        return C(t.create.apply(t, arguments));
      },
    });
  }
  function C(t) {
    var e = O(t);
    return (
      ["request", "auth", "download", "encrypt"].forEach(function (r) {
        e[r] = t[r].bind(t);
      }),
      e
    );
  }
  var A = (function (t) {
    function n() {
      return t.apply(this, arguments) || this;
    }
    r(n, t);
    var i = n.prototype;
    return (
      (i.requestAdapter = function (t, e) {
        return (function (t, e) {
          var r = new XMLHttpRequest(),
            n = t.url,
            i = t.method || "POST",
            s = a(t.params),
            c = !!t.formData,
            u = "",
            h = t.signal;
          function f() {
            r.abort();
          }
          function p(r, n) {
            h && h.removeEventListener("abort", f), e(t.options, r, n);
          }
          function l() {
            p(!1, new Error("aborted"));
          }
          if (h && h.aborted) l();
          else {
            if (
              (s.length > 0 && ("GET" === i || c ? (n += "?" + s) : (u = s)), c)
            )
              for (var d in ((u = new FormData()), t.formData))
                o(t.formData, d) && u.append(d, t.formData[d]);
            for (var v in (r.open(i, n, !0),
            "number" == typeof t.timeout && (r.timeout = t.timeout),
            (r.ontimeout = function () {
              p(!1, new Error("timeout"));
            }),
            (r.onload = function () {
              p(200 === r.status, r.response);
            }),
            (r.onerror = function () {
              p(!1, r.response);
            }),
            (r.onabort = l),
            t.onDownloadProgress &&
              r.addEventListener("progress", t.onDownloadProgress),
            t.onUploadProgress &&
              r.upload &&
              r.upload.addEventListener("progress", t.onUploadProgress),
            h && h.addEventListener("abort", f),
            t.headers))
              (c && "POST" === i && "Content-Type" === v) ||
                r.setRequestHeader(v, t.headers[v]);
            r.send(u);
          }
        })(t, e);
      }),
      (i.prepare = function (r) {
        return e({}, t.prototype.prepare.call(this, r), {
          formData: r.formData,
          onDownloadProgress: r.onDownloadProgress,
          onUploadProgress: r.onUploadProgress,
        });
      }),
      (i.createRequestConfig = function (r) {
        return e({}, t.prototype.createRequestConfig.call(this, r), {
          formData: r.formData,
          onDownloadProgress: r.onDownloadProgress,
          onUploadProgress: r.onUploadProgress,
        });
      }),
      n
    );
  })(w);
  function q(t, e) {
    var r = t.url,
      n = t.method || "GET",
      i = t.params || {},
      s = null;
    "GET" === n
      ? (r += "?" + a(i))
      : "POST" === n &&
        (r =
          H && "https:" === location.protocol
            ? 'javascript:""'
            : "about:blank");
    var c,
      u,
      h,
      f =
        ((c = r),
        (u = document.createElement("iframe")),
        (h = "synowebapi-iframe-" + P++),
        u.setAttribute("src", c),
        u.setAttribute("frameBorder", "0"),
        u.setAttribute("id", h),
        u.setAttribute("name", h),
        u.setAttribute(
          "style",
          "border:0px none;width:0;height:0;position:absolute;top:-100000px"
        ),
        document.body.appendChild(u),
        u);
    function p() {
      return f.contentWindow
        ? f.contentWindow.document || f.contentDocument
        : f.contentDocument || window.frames[f.id].document;
    }
    "POST" === n &&
      ((s = (function (t, e) {
        var r = document.createElement("form");
        (r.name = "dlform"), (r.method = "POST");
        var n = e.SynoToken;
        n &&
          ((t += "?SynoToken=" + n),
          delete (e = Object.assign({}, e)).SynoToken);
        for (var i in ((r.action = t), e))
          if (o(e, i)) {
            var s = document.createElement("input");
            (s.type = "hidden"),
              (s.name = i),
              (s.value = e[i]),
              r.appendChild(s);
          }
        return r;
      })(t.url, i)),
      p().body.appendChild(s));
    var l = null;
    function d(r, n) {
      l && (clearTimeout(l), (l = null)),
        e && e(t.options, "load" === r, n),
        setTimeout(function () {
          try {
            document.body.removeChild(f);
          } catch (t) {}
        }, 100);
    }
    t.timeout &&
      (l = setTimeout(function () {
        d("timeout", new Error("timeout"));
      }, t.timeout)),
      f.addEventListener(
        "load",
        function () {
          var t = p().body.firstChild;
          d("load", t && t.innerHTML);
        },
        { once: !0 }
      ),
      f.addEventListener(
        "error",
        function () {
          d("error");
        },
        { once: !0 }
      ),
      s && (s.submit(), s.parentNode.removeChild(s));
  }
  var P = 0;
  var z,
    F,
    j,
    L,
    H =
      ((z = navigator.userAgent.toLowerCase()),
      (F = /msie/.test(z)),
      (j = /trident\/7/.test(z)),
      F || j),
    U = (function (t) {
      function n(e, r) {
        var n;
        return ((n = t.call(this, e) || this).xhrRelayTarget = r), n;
      }
      r(n, t);
      var i = n.prototype;
      return (
        (i.request = function (e) {
          t.prototype.request.call(this, e).catch(function (t) {
            (s(t) && "timeout" === t.message) ||
              (e.onError && e.onError.call(e.scope, t));
          });
        }),
        (i.requestAdapter = function (t, e) {
          return q(t, e);
        }),
        (i.createRequestConfig = function (e) {
          var r = t.prototype.createRequestConfig.call(this, e);
          r.header = null;
          var n = this.env.getSynoToken();
          return (
            n && (r.params = Object.assign({}, r.params, { SynoToken: n })), r
          );
        }),
        (i.prepare = function (r) {
          var n, i;
          return e({}, t.prototype.prepare.call(this, r), {
            requestMethod: null != (n = r.requestMethod) ? n : "GET",
            timeout: null != (i = r.timeout) ? i : 12e4,
          });
        }),
        (i.encryptParams = function (e, r) {
          return this.xhrRelayTarget
            ? this.xhrRelayTarget.encryptParams(e, r)
            : t.prototype.encryptParams.call(this, e, r);
        }),
        n
      );
    })(w),
    N = (function (t) {
      function e() {
        return t.apply(this, arguments) || this;
      }
      return (
        r(e, t),
        (e.prototype._isSecure = function () {
          var t = this.getBaseURL();
          return (/^https?:\/\//.test(t) ? t : location.protocol).startsWith(
            "https:"
          );
        }),
        e
      );
    })(i);
  return e(
    {},
    M(
      (L = new ((function (t) {
        function e(e) {
          var r;
          void 0 === e && (e = Object.create(null)), (r = t.call(this) || this);
          var n = new N(e);
          return (
            (r.manager = new A(n)), (r.downloader = new U(n, r.manager)), r
          );
        }
        return (
          r(e, t),
          (e.prototype.download = function (t) {
            this.downloader.request(t);
          }),
          e
        );
      })(D))())
    ),
    {
      create: function () {
        return M(L.create.apply(L, arguments));
      },
      promises: R(L),
      AbortController: {
        create: function () {
          return new x();
        },
      },
    }
  );
})();
