using BSMVCprj.APIModels;
using BSMVCprj.Models;
using BSMVCprj.Repository.API;
using BSMVCprj.Repository.token;
using BSMVCprj.Services.API;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BSMVCprj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Auth : ControllerBase
    {
        private readonly IAPIBALANCE _balance;
        private readonly IAPIUSER _user;

        private readonly IAUTH _auth;
        private readonly IBETT _bettt;
        private readonly IWINN _winnn;
        private readonly ICANCELBETT _cancelbettt;
        private readonly ICHANGEWINN _changewinn;
        public Auth(IAPIBALANCE balance, IAPIUSER user, IAUTH auth,
            IBETT bettt, IWINN winnn, ICANCELBETT cancelbettt, ICHANGEWINN winnz)
        {
            _balance = balance; _user = user; _auth = auth; _bettt = bettt;
            _winnn = winnn; _cancelbettt = cancelbettt; _changewinn = winnz;
        }

        [HttpPost("bsauth")]
        public IActionResult Bsauth(string Token)
        {
            try
            {
                var model = new TokenModel();
                 _auth.Authentification(out model, Token, "Active");
                if (model.Check == 7)
                {
                    return Ok(new
                    {
                        StatusCode = 401
                    });
                }
                return Ok(new
                {
                    StatusCode = 200,
                    Data = new
                    {
                        PrivateToken = model.TokenId,
                    }

                });
            }
            catch (Exception)
            {
                return Ok(new
                {
                    StatusCode = 500
                });
            }

        }
        [HttpPost("userinfo")]
        public IActionResult Userinfo(string Token)
        {
            try
            {
                var Model = new TokenModel();
                var userr =  _user.ApiUser(Token, "Active",out Model);
                if (Model.Check == 7)
                {
                    return Ok(new
                    {
                        StatusCode = 401
                    });
                }
                if (userr.Count() == 0)
                {
                    return Ok(new
                    {
                        StatusCode = 401
                    });
                }
                if (Token.Length < 30 || Token.Length > 40)
                {
                    return Ok(new
                    {
                        StatusCode = 404
                    });
                }

                return Ok(new
                {
                    StatusCode = 200,
                    Data = userr

                });
            }
            catch
            {
                return Ok(new
                {
                    StatusCode = 500
                });
            }
        }
        [HttpPost("bet")]
        public async Task<IActionResult> Bet(string Token, int RemoteTranId, decimal Amount)
        {
            try
            {
                string Transtype = "Bet";
                var model = new TokenModel();
                model.TransactionId = RemoteTranId;
                await _bettt.Bettzor(Token, RemoteTranId, Transtype, Amount, model);
                if (model.Check == 7)
                {
                    return Ok(new
                    {
                        StatusCode = 401
                    });
                }
                if (model.Check == 2)
                {
                    return Ok(new
                    {
                        StatusCode = 408
                    });
                }
                if (model.Check == 9)
                {
                    return Ok(new
                    {
                        StatusCode = 402
                    });
                }
                if (model.Check == 1)
                {
                    return Ok(new
                    {
                        StatusCode = 408
                    });
                }
                if (model is null)
                {
                    return Ok(new
                    {
                        StatusCode = 406
                    });
                }

                return Ok(new
                {
                    StatusCode = 200,
                    Data = new
                    {
                        TransactionId = model.TransactionId,
                        currentbalance = model.CurrentBalance * 100,
                    }
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    StatusCode = 401,
                    exception = ex.Message

                });
            }
        }
        [HttpPost("win")]
        public IActionResult Win(string Token, int RemoteTranId, decimal Amount)
        {
            try
            {

                var model = new TokenModel();
                string Transtype = "Win";
                model.TransactionId = RemoteTranId;
                _winnn.Winnzor(Token, RemoteTranId, Transtype, Amount,out model);
                if (model.Check == 7)
                {
                    return Ok(new
                    {
                        StatusCode = 404
                    });
                }
                if (model.Check == 2)
                {
                    return Ok(new
                    {
                        StatusCode = 201
                    });
                }
                if (model.Check == 1)
                {
                    return Ok(new
                    {
                        StatusCode = 408
                    });
                }
                if (model is null)
                {
                    return Ok(new
                    {
                        StatusCode = 406
                    });
                }
                return Ok(new
                {
                    StatusCode = 200,
                    Data = new
                    {
                        RemoteTranId = RemoteTranId,
                        CurrentBalance = model.CurrentBalance * 100,
                    }
                });
            }
            catch (Exception)
            {
                return Ok(new
                {
                    StatusCode = 401
                });
            }
        }
        [HttpPost("cancelbet")]
        public IActionResult CancelBet(string PrivateToken, decimal Amount, int TransactionId, int PTransactionId)
        {
            try
            {
                var model = new TokenModel();
                _cancelbettt.CancelBett(PrivateToken, TransactionId, PTransactionId, Amount,out model);
                if (model.Check == 7)
                {
                    return Ok(new
                    {
                        StatusCode = 401
                    });
                }
                if (model.Check == 6)
                {
                    return Ok(new
                    {
                        StatusCode = 411
                    });
                }
                if (model.Check == 2)
                {
                    return Ok(new
                    {
                        StatusCode = 201
                    });
                }
                if (model.Check == 5)
                {
                    return Ok(new
                    {
                        StatusCode = 407
                    });
                }

                if (model.Check == 3)
                {
                    return Ok(new
                    {
                        StatusCode = 500
                    });
                }
                if (TransactionId < 1)
                {
                    return Ok(new
                    {
                        StatusCode = 406
                    });
                }

                return Ok(new
                {
                    StatusCode = 200,
                    Data = new
                    {
                        TransactionId = TransactionId,
                        CurrentBalance = model.CurrentBalance * 100,

                    }
                });
            }
            catch (Exception)
            {
                return Ok(new
                {
                    StatusCode = 500
                });
            }
        }
        [HttpPost("changewin")]
        public IActionResult Changewin(string PrivateToken, decimal Amount, decimal Pamount, int TransactionId, int PTransactionId)
        {
            try
            {

                var model = new TokenModel();
                _changewinn.ChangeWinn(PrivateToken, TransactionId, PTransactionId, Amount, Pamount,out model);
                if (model.Check == 7)
                {
                    return Ok(new
                    {
                        StatusCode = 401
                    });
                }

                if (model.Check == 6)
                {
                    return Ok(new
                    {
                        StatusCode = 411
                    });
                }
                if (model.Check == 2)
                {
                    return Ok(new
                    {
                        StatusCode = 201
                    });
                }
                if (model.Check == 5)
                {
                    return Ok(new
                    {
                        StatusCode = 407
                    });
                }
                if (model.Check == 3)
                {
                    return Ok(new
                    {
                        StatusCode = 404
                    });
                }
                if (TransactionId < 1)
                {
                    return Ok(new
                    {
                        StatusCode = 406
                    });
                }

                return Ok(new
                {
                    StatusCode = 200,
                    Data = new
                    {
                        TransactionId = TransactionId,
                        CurrentBalance = model.CurrentBalance * 100

                    }
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    StatusCode = ex.Message
                });
            }
        }
        [HttpPost("getbalance")]
        public IActionResult GetBalance(string Token)
        {
            try
            {
                var model = new TokenModel();
                 _balance.Balance(Token, "Active", out model);
                if (model.Check == 7)
                {
                    return Ok(new
                    {
                        StatusCode = 401
                    });
                }
                
                if (Token.Length < 30 || Token.Length > 40)
                {
                    return Ok(new
                    {
                        StatusCode = 404
                    });
                }
                return Ok(new
                {
                    StatusCode = 200,
                    Data = new
                    {
                        CurrentBalance = model.CurrentBalance * 100,
                    }
                });
            }
            catch (Exception)
            {
                return Ok(new
                {
                    StatusCode = 500
                });
            }
        }
        private static string GetSha256(string text)
        {
            var utf8Encoding = new UTF8Encoding();
            var message = utf8Encoding.GetBytes(text);

            var hashString = new SHA256Managed();
            var hex = string.Empty;

            var hashValue = hashString.ComputeHash(message);

            return hashValue.Aggregate(hex, (current, bt) => current + $"{bt:x2}");
        }
    }

}
