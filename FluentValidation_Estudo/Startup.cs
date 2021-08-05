using FluentValidation.AspNetCore;
using FluentValidation_Estudo.Domain.CommandHandlers;
using FluentValidation_Estudo.Domain.Commands;
using FluentValidation_Estudo.Domain.Notification;
using FluentValidation_Estudo.Domain.Queries;
using FluentValidation_Estudo.Domain.Queries.Result;
using FluentValidation_Estudo.Domain.QueryHandlers;
using FluentValidation_Estudo.Domain.Validations;
using FluentValidation_Estudo.Infra.BehaviorMediatR;
using FluentValidation_Estudo.Infra.Data;
using FluentValidation_Estudo.Validators;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace FluentValidation_Estudo
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			services.AddControllers()
					.AddFluentValidation(config =>
					config.RegisterValidatorsFromAssemblyContaining<CreatePersonCommandValidation>()
						  .RegisterValidatorsFromAssemblyContaining<AdicionarPessoaValidator>());

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "FluentValidation_Estudo", Version = "v1" });
			});


			services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationRequestBehavior<,>));
			services.AddMediatR(typeof(Startup));
			services.AddScoped<IDomainNotificationContext, DomainNotificationContext>();
			services.AddScoped<IPersonRepository, PersonRepository>();
			services.AddScoped<AsyncRequestHandler<CreatePersonCommand>, PersonCommandHandler>();
			services.AddScoped<IRequestHandler<GetPagedPersonsQuery, IEnumerable<GetPagedPersonsQueryResult>>, PersonQueryHandler>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FluentValidation_Estudo v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
