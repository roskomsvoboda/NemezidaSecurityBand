using System;
using System.Drawing;
using LazZiya.ImageResize;
using FluentArgs;
using System.Threading.Tasks;
namespace FakeAppWaterMarker
{
    class Program
    {
        static Task Main(string[] args)
        {
            //Console.WriteLine();
            //Console.WriteLine("Hello World!");
            return FluentArgsBuilder.New()
                .DefaultConfigsWithAppDescription("An app add watermark on image.")
                .Parameter("-i", "--input_image")
                    .WithDescription("Input png file")
                    .WithExamples("input.png")
                    .IsRequired()
                .Parameter("-o", "--output_image")
                    .WithDescription("Output jpg file")
                    .WithExamples("output.jpg")
                    .IsRequired()
                .Parameter("-w", "--watermark_image")
                    .WithDescription("Output jpg file")
                    .WithExamples("output.jpg")
                    .IsRequired()
                .Parameter<int>("-l", "--level_opacity")
                    .WithDescription("level_opacity")
                    .WithValidation(n => n >= 0 && n <= 100)
                    .IsOptionalWithDefault(50)
                .Call(level_opacity => watermark_image => outputFile => inputFile =>
                {
                    ApplyWaterMarkSingleImage(inputFile, watermark_image, outputFile, level_opacity);
                    return Task.CompletedTask;
                })
                .ParseAsync(args);



        }

      static void ApplyWaterMarkSingleImage(String InputImage, String WaterMarkImage, String OutImage, int OpacityWaterMark)
        {
            using (var img = Image.FromFile(InputImage))
            {
                var iOps = new ImageWatermarkOptions
                {
                    // Change image opacity (0 - 100)
                    Opacity = OpacityWaterMark,
                    Location = TargetSpot.BottomRight
                };

                img.AddImageWatermark(WaterMarkImage, iOps)
                   .SaveAs(OutImage);
            }

        }

    }
}

