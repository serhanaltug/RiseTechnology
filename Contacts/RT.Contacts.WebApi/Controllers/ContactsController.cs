using Microsoft.AspNetCore.Mvc;
using RT.Contacts.Business.Abstract;
using RT.Contacts.Domain.Entities;

namespace RT.Contacts.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        IContactService _contacts;

        public ContactsController(IContactService contacts)
        {
            _contacts = contacts;
        }

        #region Contacts

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = _contacts.GetAll();
            if(result.Success) return Ok(result);
            else return BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var result = _contacts.GetByIdWithDetails(id);
            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(Contact contact)
        {
            var result = _contacts.Add(contact);
            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, Contact contact)
        {
            var entity = _contacts.GetById(id);
            if (!entity.Success) return NotFound(entity);

            var result = _contacts.Update(contact);
            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var entity = _contacts.GetById(id);
            if (entity.Data == null) return NotFound(entity);

            var result = _contacts.Delete(entity.Data);
            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }

        #endregion

        #region Details

        [HttpGet("details/{contactId}")]
        public async Task<IActionResult> GetAllDetails(int contactId)
        {
            var result = _contacts.GetAllDetailsById(contactId);
            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }

        [HttpGet("details/{contactId}/{detailId}")]
        public async Task<IActionResult> GetDetailById(int contactId, int detailId)
        {
            var contact = _contacts.GetById(contactId);
            if (contact.Data != null)
            {
                var result = _contacts.GetDetailById(detailId);
                if (result.Success) return Ok(result);
                else return BadRequest(result);
            }
            return NotFound("Contact not found");
        }

        [HttpPost("details/{contactId}")]
        public async Task<IActionResult> AddDetail(int contactId, ContactDetail detail)
        {
            var entity = _contacts.GetById(contactId);
            if (entity.Data != null) {
                var result = _contacts.AddDetail(detail);
                if (result.Success) return Ok(result);
                else return BadRequest(result);
            }
            return NotFound("Contact not found");
        }

        [HttpPut("details/{contactId}/{detailId}")]
        public async Task<IActionResult> UpdateDetail(int contactId, int detailId, ContactDetail detail)
        {
            var contact = _contacts.GetById(contactId);
            if (contact.Data != null)
            {
                var contactDetail = _contacts.GetDetailById(detailId);
                if (contactDetail.Data != null && contactDetail.Data.Id == detail.Id)
                {
                    var result = _contacts.UpdateDetail(detail);
                    if (result.Success) return Ok(result);
                    else return BadRequest(result);
                }
                else return NotFound("Details not found");

            }
            return NotFound("Contact not found");
        }

        [HttpDelete("details/{contactId}/{detailId}")]
        public async Task<IActionResult> DeleteDetail(int contactId, int detailId)
        {
            var contact = _contacts.GetById(contactId);
            if (contact.Data != null)
            {
                var contactDetail = _contacts.GetDetailById(detailId);
                if (contactDetail.Data != null)
                {
                    var result = _contacts.DeleteDetail(contactDetail.Data);
                    if (result.Success) return Ok(result);
                    else return BadRequest(result);
                }
                else return NotFound("Details not found");

            }
            return NotFound("Contact not found");
        }

        #endregion
    }
}
